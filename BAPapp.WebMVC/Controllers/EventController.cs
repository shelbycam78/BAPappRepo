using BAPapp.Models.Event;
using BAPapp.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BAPapp.WebMVC.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
    
        // GET: Event
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EventService(userId);
            var model = service.GetEvents();

            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }

        //POST: create event
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventCreate model)
        {

            if (!ModelState.IsValid) return View(model);

            var service = CreateEventService();

            service.CreateEvent(model);


            if (service.CreateEvent(model))
            {
                TempData["SaveResult"] = "Your event was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Event could not be created");
            return View(model);

            
        }
        public ActionResult Details(DateTime eventDate)
        {
            var svc = CreateEventService();
            var model = svc.GetEventByDate(eventDate);

            return View(model);
        }
        private EventService CreateEventService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EventService(userId);
            return service;
        }



        public ActionResult Edit(DateTime eventDate)
        {
            var service = CreateEventService();
            var detail = service.GetEventByDate(eventDate);
            var model =
                new EventEdit
                {
                    
                    EventDate = detail.EventDate,
                    EventTitle = detail.EventTitle,
                    
                    Position = detail.Position,
                    Director = detail.Director,
                    Producer = detail.Producer,
                    IsPaid = detail.IsPaid,
                    IsTaxed = detail.IsTaxed,
                    IsDirectDeposit = detail.IsDirectDeposit
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DateTime eventDate, EventEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.EventDate != eventDate)
            {
                ModelState.AddModelError("", "EVentDate mismatch.");
                return View(model);
            }

            var service = CreateEventService();

            if (service.UpdateEvent(model))
            {
                TempData["SaveResult"] = "Your event was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your event could not be updated.");
            return View(model);
        }
        public ActionResult Delete(DateTime eventDate)
        {
            var svc = CreateEventService();
            var model = svc.GetEventByDate(eventDate);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEvent(int eventId)
        {
            var service = CreateEventService();

            service.DeleteEvent(eventId);

            TempData["Save Result"] = "Your event was deleted.";

            return RedirectToAction("Index");
        }

        

    }
}