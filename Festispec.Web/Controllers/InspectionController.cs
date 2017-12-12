using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult Inspect(int inspectionId)
        {
            ViewBag.Message = "Inspectie uitvoeren.";

            using (var inspectionRepository = _inspectionRepositoryFactory.CreateRepository())
            {
                var inspection = inspectionRepository.Get(inspectionId);

                return View(inspection);
            }
        }
    }
}