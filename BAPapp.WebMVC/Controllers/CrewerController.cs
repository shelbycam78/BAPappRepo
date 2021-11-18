using BAPapp.Models.Crewer;
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
    [Authorize]
    public class CrewerController : Controller
    {
        // GET: Crewer
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CrewerService(userId);
            var model = service.GetCrewers();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
        //POST:  Crewer

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CrewerCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCrewerService();

            service.CreateCrewer(model);

            if (service.CreateCrewer(model))
            {
                TempData["SaveResult"] = "A crewer was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Crewer could not be created");
            return View(model);
        }

        public ActionResult Details(string name)
        {
            var svc = CreateCrewerService();
            var model = svc.GetCrewerByName(name);

            return View(model);

        }
        private CrewerService CreateCrewerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CrewerService(userId);
            return service;
        }

        //GET:  Edit
        //Crewer/Edit/CrewerId
        public ActionResult Edit(string name)
        {
            var service = CreateCrewerService();
            var detail = service.GetCrewerByName(name);
            var model =
                new CrewerEdit
                {
                    CrewerId = detail.CrewerId,
                    Name = detail.Name,
                    Email = detail.Email,
                    Phone = detail.Phone,
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string name, CrewerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.Name != name)
            {
                ModelState.AddModelError("", "Crewer Name mismatch.");
                return View(model);
            }

            var service = CreateCrewerService();

            if (service.UpdateCrewer(model))
            {
                TempData["SaveResult"] = "The crewer was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The crewer could not be updated.");
            return View(model);

        }
        //GET:  Delete
        //Crewer/Delete/CrewerId
        public ActionResult Delete(string name)
        {
            var svc = CreateCrewerService();
            var model = svc.GetCrewerByName(name);

            return View(model);
        }

        //POST: Delete
        //Crewer/Delete/CrewerId
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCrewer(string name)
        {
            var service = CreateCrewerService();

            service.DeleteCrewer(name);

            TempData["SeveResult"] = "The crewer was deleted";

            return RedirectToAction("Index");
        }

    }
}