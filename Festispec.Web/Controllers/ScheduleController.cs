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
            using (var scheduleRepository = _inspectorScheduleRepositoryFactory.CreateRepository())
            {
                var schedule = scheduleRepository.Get().ToList();

                return View(schedule);
            }
        }

        [HttpPost]
        public ActionResult Create()
        {
            Schedule temp = new Schedule();
            using (var scheduleRepository = _inspectorScheduleRepositoryFactory.CreateRepository())
            {
                scheduleRepository.Add(temp);
                var schedule = scheduleRepository.Get().ToList();
                return View(schedule);
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