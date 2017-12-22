using Festispec.Domain;
using Festispec.Domain.Repository.Factory;
using Festispec.Domain.Repository.Factory.Interface;
using Festispec.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Festispec.Web.Controllers
{
    [Authorize]
    public class ScheduleController : Controller
    {
        private readonly IInspectorScheduleRepositoryFactory _inspectorScheduleRepositoryFactory;

        public int _inspectorId { get; set; }

        public ScheduleController()
        {
            _inspectorScheduleRepositoryFactory = new InspectorScheduleRepositoryFactory(true);
        }

        public ActionResult InspectorSchedule(int? id)
        {
            ViewBag.Message = "Rooster Inspecteur.";

            var user = ((IInspectorPrincipal)User);
            _inspectorId = user.Id;

            using (var scheduleRepository = _inspectorScheduleRepositoryFactory.CreateRepository())
            {
                if (id.HasValue)
                {
                    scheduleRepository.Delete(id.Value);
                    return Redirect("/Schedule/InspectorSchedule");
                }

                var schedulee = scheduleRepository.Get().Where(schedule => schedule.Inspector_Id == _inspectorId).ToList();
                return View(schedulee);
            }
        }

        public ActionResult AddAvailability(int? id)
        {
            ViewBag.Message = "Beschikbaarheid toevoegen";

            if (!id.HasValue) {
                var user = ((IInspectorPrincipal)User);
                _inspectorId = user.Id;

                return View(new Schedule {Inspector_Id = _inspectorId});
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
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }

            using (var scheduleRepository = _inspectorScheduleRepositoryFactory.CreateRepository())
            {
                if (!ModelState.IsValid)
                {
                    if (temp.NotAvailableFrom < temp.NotAvailableTo)
                    {
                        if (temp.Id == 0)
                        {
                            scheduleRepository.Add(temp);
                        }
                        else
                        {
                            scheduleRepository.Update(temp, temp.Id);
                        }
                    }
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