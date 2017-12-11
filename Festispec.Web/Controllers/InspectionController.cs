using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Festispec.Web.Controllers
{
    public class InspectionController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Inspecties.";

            return View();
        }
        public ActionResult Inspect(int inspectionId)
        {
            ViewBag.Message = "Inspectie uitvoeren.";

            return View();
        }
    }
}