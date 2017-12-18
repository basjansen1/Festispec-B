using Festispec.Domain;
using Festispec.Domain.Repository.Factory;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Web.Models;
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

        private readonly int _inspectorId;

        public ScheduleController()
        {
            _inspectorScheduleRepositoryFactory = new InspectorScheduleRepositoryFactory(true);

            var user = ((IInspectorPrincipal)User);
            _inspectorId = user.Id;
        }

        public ActionResult InspectorSchedule(int? id)
        {
            ViewBag.Message = "Rooster Inspecteur.";

            using (var scheduleRepository = _inspectorScheduleRepositoryFactory.CreateRepository())
            {
                if (id.HasValue)
                {

                    scheduleRepository.Delete(id.Value);
                    return Redirect("/Schedule/InspectorSchedule");
                }

                var schedulee = scheduleRepository.Get().ToList();
                return View(schedulee);
            }
        }

        public ActionResult AddAvailability(int? id)
        {
            ViewBag.Message = "Beschikbaarheid toevoegen";

            if (!id.HasValue) {
                return View(new Schedule());
            }
            
            using (var scheduleRepository = _inspectorScheduleRepositoryFactory.CreateRepository())
            {
                var schedule = scheduleRepository.Get(id.Value);

                return View(schedule);
            }

        }

        [HttpPost]
        public ActionResult Create(Schedule temp)
        {
            using (var scheduleRepository = _inspectorScheduleRepositoryFactory.CreateRepository())
            {
                    temp.Inspector_Id = 4; //debug TODO: login authentication dignes
                if (temp.Id == 0)
                {
                    scheduleRepository.Add(temp);
                } else
                {
                    scheduleRepository.Update(temp, temp.Id);
                }

                return RedirectToAction("InspectorSchedule");
            }
        }

        public ActionResult GetSchedule()
        {
            ViewBag.Message = "Rooster uitvoeren.";



            using (var scheduleRepository = _inspectorScheduleRepositoryFactory.CreateRepository())
            {
                var schedule = scheduleRepository.Get(_inspectorId);

                return View(schedule);
            }
        }
    }
}