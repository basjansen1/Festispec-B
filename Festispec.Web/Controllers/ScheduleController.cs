using Festispec.Domain;
using Festispec.Domain.Repository.Factory;
using Festispec.Domain.Repository.Factory.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Festispec.Web.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly IInspectorScheduleRepositoryFactory _inspectorScheduleRepositoryFactory;

        public ScheduleController()
        {
            _inspectorScheduleRepositoryFactory = new InspectorScheduleRepositoryFactory(true);
        }

        public ActionResult InspectorSchedule()
        {
            ViewBag.Message = "Rooster Inspecteur.";
            using (var scheduleRepository = _inspectorScheduleRepositoryFactory.CreateRepository())
            {
                var schedule = scheduleRepository.Get().ToList();

                return View(schedule);
            }
        }

        public ActionResult AddAvailability()
        {
            ViewBag.Message = "Beschikbaarheid toevoegen";

            Schedule schedule = new Schedule();

            return View(schedule);
            
        }

        [HttpPost]
        public ActionResult Create(Schedule temp)
        {
            using (var scheduleRepository = _inspectorScheduleRepositoryFactory.CreateRepository())
            {
                //if (!ModelState.IsValid)
                //{
                    temp.Inspector_Id = 4; //debug TODO: login authentication dignes
                    scheduleRepository.Add(temp);
                    return RedirectToAction("InspectorSchedule");
                //}
            }
        }

        public ActionResult GetSchedule(int inspectorId)
        {
            ViewBag.Message = "Rooster uitvoeren.";

            using (var scheduleRepository = _inspectorScheduleRepositoryFactory.CreateRepository())
            {
                var schedule = scheduleRepository.Get(inspectorId);

                return View(schedule);
            }
        }
    }
}