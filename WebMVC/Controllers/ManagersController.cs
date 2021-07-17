using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models.Entity;
using WebMVC.Repositories;

namespace WebMVC.Controllers
{
    public class ManagersController : Controller
    {
        ManagerRepository managerRepository = new ManagerRepository();

        // GET: Manager
        public ActionResult Index()
        {
            var result = managerRepository.List();
            return View(result);
        }

        [HttpGet]
        public ActionResult ManagerAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ManagerAdd(Manager manager)
        {
            if (!ModelState.IsValid)
            {
                return View("ManagerAdd");
            }
            managerRepository.TAdd(manager);
            return RedirectToAction("Index");
        }

        public ActionResult ManagerDelete(int id)
        {
            Manager manager = managerRepository.Find(m => m.Id == id);
            managerRepository.TDelete(manager);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ManagerUpdate(int id)
        {
            Manager manager = managerRepository.Find(m => m.Id == id);
            return View(manager);
        }

        [HttpPost]
        public ActionResult ManagerUpdate(Manager manager)
        {
            Manager managerr= managerRepository.Find(m =>m.Id == manager.Id);
            managerr.AdminName = manager.AdminName;
            managerr.AdminPassword = manager.AdminPassword;
            managerRepository.TUpdate(managerr);
            return RedirectToAction("Index");
        }
    }
}