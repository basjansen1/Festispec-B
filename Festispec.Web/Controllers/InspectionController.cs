using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Festispec.Domain.Repository.Factory;
using Festispec.Domain.Repository.Factory.Interface;

namespace Festispec.Web.Controllers
{
    public class InspectionController : Controller
    {
        private readonly IInspectionRepositoryFactory _inspectionRepositoryFactory;

        public InspectionController()
        {
            _inspectionRepositoryFactory = new InspectionRepositoryFactory(true);
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Inspecties.";

            return View();
        }
        public ActionResult Inspect(int? id)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ViewBag.Message = "Inspectie uitvoeren.";

            using (var inspectionRepository = _inspectionRepositoryFactory.CreateRepository())
            {
                var inspection = inspectionRepository.Get().FirstOrDefault(i => i.Id == id.Value);

                if (inspection == null)
                    return HttpNotFound();

                return View(inspection);
            }
        }
        [HttpPost]
        public ActionResult Inspect(int? id, Dictionary<int, string> answers)
        {
            if (!id.HasValue)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            int inspectionId = id.Value;
            int inspectorId = 3; // TODO: User.EntityKey;
            DateTime date = new DateTime();

            using (var _inspectionRepository = _inspectionRepositoryFactory.CreateRepository())
            {
                foreach (KeyValuePair<int, string> answer in answers)
                {
                    // TODO: AddorUpdate(answer.key, answer.value);
                    var a = answer.Key;
                    var b = answer.Value;

                    _inspectionRepository.AddOrUpdateQuestionAnswer(inspectionId, inspectorId, date, answer.Key, answer.Value);
                }
            }

            return RedirectToAction(nameof(Inspect), inspectionId);
        }
    }
}