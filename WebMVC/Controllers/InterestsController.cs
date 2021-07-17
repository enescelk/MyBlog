using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models.Entity;
using WebMVC.Repositories;

namespace WebMVC.Controllers
{
    public class InterestsController : Controller
    {
        InterestsRepository interetsRepository = new InterestsRepository();
        // GET: Interests
        public ActionResult Index()
        {
            var result = interetsRepository.List();
            return View(result);
        }

        [HttpGet]
        public ActionResult InteretsAdd()
        {

            return View();
        }

        [HttpPost]
        public ActionResult InteretsAdd(Interest interet)
        {
            if (!ModelState.IsValid)
            {
                return View("InteretsAdd");
            }
            interetsRepository.TAdd(interet);
            return RedirectToAction("Index");
        }

        public ActionResult InteretsDelete(int id)
        {
            Interest interet = interetsRepository.Find(x => x.Id == id);
            interetsRepository.TDelete(interet);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult InteretsUpdate(int id)
        {
            Interest interet = interetsRepository.Find(x => x.Id == id);
            return View(interet);
        }

        [HttpPost]
        public ActionResult InteretsUpdate(Interest interet)
        {
            Interest i = interetsRepository.Find(x => x.Id == interet.Id);
            i.InteretsDescription = interet.InteretsDescription;
            i.InteretsTwoDescription = interet.InteretsTwoDescription;
            interetsRepository.TUpdate(i);
            return RedirectToAction("Index");
        }
    }
}