using BAPapp.Data;
using BAPapp.Models;
using BAPapp.Models.Venue;
using BAPapp.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BAPapp.WebMVC.Controllers
{
    public class VenueController : Controller
    {
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new VenueService(userId);
            var model = service.GetVenues();
            
      
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
        //POST:  Crewer

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VenueCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateVenueService();

            service.CreateVenue(model);

            if (service.CreateVenue(model))
            {
                TempData["SaveResult"] = "A venue was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Venue could not be created");
            return View(model);
        }

        public ActionResult Details(string venueName)
        {
            var svc = CreateVenueService();
            var model = svc.GetVenueByName(venueName);

            return View(model);

        }
        private VenueService CreateVenueService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new VenueService(userId);
            return service;
        }

        //GET:  Edit
        //Crewer/Edit/CrewerId
        public ActionResult Edit(string venueName)
        {
            var service = CreateVenueService();
            var detail = service.GetVenueByName(venueName);
            var model =
                new VenueEdit
                {
                    VenueId = detail.VenueId,
                    VenueName = detail.VenueName,
                    VenueLocation = detail.VenueLocation,
                    PointOfContact = detail.PointOfContact,
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string venueName, VenueEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.VenueName != venueName)
            {
                ModelState.AddModelError("", "Venue Name mismatch.");
                return View(model);
            }

            var service = CreateVenueService();

            if (service.UpdateVenue(model))
            {
                TempData["SaveResult"] = "The venue was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The venue could not be updated.");
            return View(model);

        }
        //GET:  Delete
        //Crewer/Delete/CrewerId
        public ActionResult Delete(string name)
        {
            var svc = CreateVenueService();
            var model = svc.GetVenueByName(name);

            return View(model);
        }

        //POST: Delete
        //Crewer/Delete/CrewerId
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteVenue(string name)
        {
            var service = CreateVenueService();

            service.DeleteVenue(name);

            TempData["SeveResult"] = "The venue was deleted";

            return RedirectToAction("Index");
        }

    }
}