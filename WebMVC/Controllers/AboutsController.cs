using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models.Entity;
using WebMVC.Repositories;

namespace WebMVC.Controllers
{
    public class AboutsController : Controller
    {
        AboutRepository aboutRepository = new AboutRepository();


        // GET: Abouts
        public ActionResult Index()
        {
            var result = aboutRepository.List();
            return View(result);
        }

        [HttpGet]
        public ActionResult AboutAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AboutAdd(About about)
        {
            if (!ModelState.IsValid)
            {
                return View("AboutAdd");
            }
            aboutRepository.TAdd(about);
            return RedirectToAction("Index");
        }

        public ActionResult AboutDelete(int id)
        {
            About about = aboutRepository.Find(a => a.Id == id);
            aboutRepository.TDelete(about);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AboutUpdate(int id)
        {
            About about = aboutRepository.Find(a => a.Id == id);
            return View(about);
        }

        [HttpPost]
        public ActionResult AboutUpdate(About about)
        {
            About a = aboutRepository.Find(x => x.Id == about.Id);
            a.FirstName = about.FirstName;
            a.LastName = about.LastName;
            a.Email = about.Email;
            a.Description = about.Description;
            a.PhoneNumber = about.PhoneNumber;
            a.Addres = about.Addres;
            aboutRepository.TUpdate(a);
            return RedirectToAction("Index");
        }
    }
}