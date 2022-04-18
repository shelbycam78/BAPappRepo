using BAPapp.Models.Client;
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

    public class ClientController : Controller
    {

        // GET: Client
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ClientService(userId);
            var model = service.GetClients();

            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.Title = "New Client";
            return View();
        }

        //POST:  Client
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateClientService();

            service.CreateClient(model);
            
            if (service.CreateClient(model))
            {
                TempData["SaveResult"] = "A client was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Client could not be created");
            return View(model);
        }

        public ActionResult Details(int clientId)
        {
            var svc = CreateClientService();
            var model = svc.GetClientById(clientId);

            return View(model);

        }
        private ClientService CreateClientService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ClientService(userId);
            return service;
        }

        //GET:  Edit
        //Client/Edit/ClientId
        public ActionResult Edit(int clientId)
        {
            var service = CreateClientService();
            var detail = service.GetClientById(clientId);
            var model =
                new ClientEdit
                {
                    ClientId = detail.ClientId,
                    Company = detail.Company,
                    Contact = detail.Contact,
              
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int clientId, ClientEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ClientId != clientId)
            {
                ModelState.AddModelError("", "Client Id mismatch.");
                return View(model);
            }

            var service = CreateClientService();

            if (service.UpdateClient(model))
            {
                TempData["SaveResult"] = "The client was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The client could not be updated.");
            return View(model);

        }
        //GET:  Delete
        //Client/Delete/ClientId
        public ActionResult Delete(int clientId)
        {
            var svc = CreateClientService();
            var model = svc.GetClientById(clientId);

            return View(model);
        }

        //POST: Delete
        //Crewer/Delete/CrewerId
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteClient(int clientId)
        {
            var service = CreateClientService();

            service.DeleteClient(clientId);

            TempData["SeveResult"] = "The client was deleted";

            return RedirectToAction("Index");
        }

    }
}
