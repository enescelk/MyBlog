using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models.Entity;
using WebMVC.Repositories;

namespace WebMVC.Controllers
{
    public class SkilsController : Controller
    {
        SkilRepository skilsRepository = new SkilRepository();
        // GET: Skils
        public ActionResult Index()
        {
            var result = skilsRepository.List();
            return View(result);
        }

        [HttpGet]
        public ActionResult SkilAdd()
        {

            return View();
        }

        [HttpPost]
        public ActionResult SkilAdd(Skil skil)
        {
            if (!ModelState.IsValid)
            {
                return View("SkilAdd");
            }
            skilsRepository.TAdd(skil);
            return RedirectToAction("Index");
        }

        public ActionResult SkilDelete(int id)
        {
            Skil skil = skilsRepository.Find(x => x.Id == id);
            skilsRepository.TDelete(skil);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SkilUpdate(int id)
        {
            Skil skil = skilsRepository.Find(x => x.Id == id);
            return View(skil);
        }

        [HttpPost]
        public ActionResult SkilUpdate(Skil skil)
        {
            Skil s = skilsRepository.Find(x => x.Id == skil.Id);
            s.SkilRate = skil.SkilRate;
            s.SkilName = skil.SkilName;
            skilsRepository.TUpdate(s);
            return RedirectToAction("Index");
        }
    }
}