using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models.Entity;
using WebMVC.Repositories;

namespace WebMVC.Controllers
{
    public class AwardsController : Controller
    {
        AwardRepository awardRepository = new AwardRepository();


        // GET: award
        public ActionResult Index()
        {
            var result = awardRepository.List();
            return View(result);
        }

        [HttpGet]
        public ActionResult AwardAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AwardAdd(Award award)
        {
            if (!ModelState.IsValid)
            {
                return View("AwardAdd");
            }
            awardRepository.TAdd(award);
            return RedirectToAction("Index");
        }

        public ActionResult AwardDelete(int id)
        {
            Award award = awardRepository.Find(a => a.Id == id);
            awardRepository.TDelete(award);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AwardUpdate(int id)
        {
            Award award = awardRepository.Find(a => a.Id == id);
            return View(award);
        }

        [HttpPost]
        public ActionResult AwardUpdate(Award award)
        {
            Award a = awardRepository.Find(x => x.Id == award.Id);
            a.award1 = award.award1;
            awardRepository.TUpdate(a);
            return RedirectToAction("Index");
        }
    }
}