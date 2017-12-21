using Festispec.Domain.Repository.Factory;
using Festispec.Domain.Repository.Factory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Festispec.Web.Controllers
{
    [Authorize]
    public class ScheduleController : Controller
    {
        private readonly IInspectorScheduleRepositoryFactory _inspectorScheduleRepositoryFactory;

        public ScheduleController()
        {
            _inspectorScheduleRepositoryFactory = new InspectorScheduleRepositoryFactory(true);
        }

        //copy pasta inspectioncontroller

        //public ActionResult Index()
        //{
        //    ViewBag.Message = "Inspecties.";

        //    return View();
        //}

        //public ActionResult Inspect(int inspectionId)
        //{
        //    ViewBag.Message = "Inspectie uitvoeren.";

        //    using (var inspectionRepository = _inspectionRepositoryFactory.CreateRepository())
        //    {
        //        var inspection = inspectionRepository.Get(inspectionId);

        //        return View(inspection);
        //    }
        //}
    }
}