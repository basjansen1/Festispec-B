using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Festispec.Domain;
using Festispec.Domain.Repository.Factory;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Web.Models;

namespace Festispec.Web.Controllers
{
    [Authorize]
    public class InspectionController : Controller
    {
        private readonly IPlanningRepositoryFactory _planningRepositoryFactory;
        private readonly IInspectionRepositoryFactory _inspectionRepositoryFactory;
        private readonly IRegulationRepositoryFactory _regulationRepositoryFactory;

        public InspectionController()
        {
            _planningRepositoryFactory = new PlanningRepositoryFactory(true);
            _inspectionRepositoryFactory = new InspectionRepositoryFactory(true);
            _regulationRepositoryFactory = new RegulationRepositoryFactory(true);
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Inspecties.";

            return View();
        }

        [Route("Inspection/Inform/")]
        public ActionResult Inform()
        {
            var user = ((IInspectorPrincipal)User);
            var id = user.Id;


            ViewBag.Messsage = "Komende Inspecties";
            IPlanningRepositoryFactory _inspectionRepositoryFactory = new PlanningRepositoryFactory(true);
            List<InspectionViewModel> _Inspections = new List<InspectionViewModel>();
            using(var InspectionRepository = _inspectionRepositoryFactory.CreateRepository())
            {
                var temp = InspectionRepository.Get().Where(  Inspection => Inspection.Inspector_Id == id);
                foreach (Planning i in temp)
                {
                    if (i.Inspection.End >= DateTime.Now.Date && i.Inspection.Status_Status != "Declined")
                    {
                        _Inspections.Add(new InspectionViewModel(i));
                    }
                }



                return View(_Inspections);

            }

        }
        
        [Route("Inspection/Inspect/{id:int}/{date:datetime}")]
        public ActionResult Inspect(int? id, DateTime? date)
        {
            if (!id.HasValue || !date.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ViewBag.Message = "Inspectie uitvoeren.";

            var user = ((IInspectorPrincipal)User);
            var inspectorId = user.Id;

            using (var planningRepository = _planningRepositoryFactory.CreateRepository())
            {
                var planning = planningRepository.Get().FirstOrDefault(i => i.Inspection_Id == id.Value && i.Inspector_Id == inspectorId && i.Date == date);

                if (planning == null)
                    return HttpNotFound();

                return View(planning);
            }
        }

        [HttpPost]
        [Route("Inspection/Inspect/{id:int}/{date:datetime}")]
        public ActionResult Inspect(int? id, DateTime? date, Dictionary<int, string> answers)
        {
            if (!id.HasValue || !date.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            var user = ((IInspectorPrincipal)User);
            var inspectorId = user.Id;

            using (var _planningRepository = _planningRepositoryFactory.CreateRepository())
            {
                var exists = _planningRepository.Get().Any(planning => planning.Inspection_Id == id && planning.Inspector_Id == inspectorId && planning.Date == date);
                if (!exists)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                foreach (KeyValuePair<int, string> answer in answers)
                {
                    _planningRepository.AddOrUpdateQuestionAnswer(id.Value, inspectorId, date.Value, answer.Key, answer.Value);
                }
            }

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        public ActionResult Regulations(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            using (var inspectionRepository = _inspectionRepositoryFactory.CreateRepository())
            {
                var inspection = inspectionRepository.Get().FirstOrDefault(i => i.Id == id);
                if (inspection == null)
                    return HttpNotFound();

                using (var regulationRepository = _regulationRepositoryFactory.CreateRepository())
                {
                    var regulations = regulationRepository.Get().Where(regulation => regulation.Municipality == inspection.Municipality || regulation.Municipality == null || regulation.Municipality == "").ToList();

                    return View(regulations);
                }
            }
        }
    }
}