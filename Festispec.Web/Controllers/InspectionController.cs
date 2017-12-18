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
    public class InspectionController : Controller
    {
        private readonly IPlanningRepositoryFactory _planningRepositoryFactory;

        public InspectionController()
        {
            _planningRepositoryFactory = new PlanningRepositoryFactory(true);
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Inspecties.";

            return View();
        }

        [Route("Inspection/Inform/")]
        public ActionResult Inform()
        {

            //TODO: Add Inspections loading in from certain ID
            //if (!id.HasValue)
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ViewBag.Messsage = "Komende Inspecties";
            IInspectionRepositoryFactory _inspectionRepositoryFactory = new InspectionRepositoryFactory(true);
            List<InspectionViewModel> _Inspections = new List<InspectionViewModel>();
            using(var InspectionRepository = _inspectionRepositoryFactory.CreateRepository())
            {

                foreach(Inspection i in InspectionRepository.Get().ToList())
                {
                    if (i.End >= DateTime.Now && i.Status.Status != "Declined")
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
            int inspectorId = 3;

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

            
            int inspectorId = 3; // TODO: User.EntityKey;

            using (var _planningRepository = _planningRepositoryFactory.CreateRepository())
            {
                var exists = _planningRepository.Get().Any(planning => planning.Inspection_Id == id && planning.Inspector_Id == inspectorId && planning.Date == date);
                if(!exists)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                
                foreach (KeyValuePair<int, string> answer in answers)
                {
                    _planningRepository.AddOrUpdateQuestionAnswer(id.Value, inspectorId, date.Value, answer.Key, answer.Value);
                }
            }

            return Inspect(id, date);
        }
    }
}