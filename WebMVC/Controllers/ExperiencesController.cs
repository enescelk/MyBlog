using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models.Entity;
using WebMVC.Repositories;

namespace WebMVC.Controllers
{
    public class ExperiencesController : Controller
    {
        ExperienceRepository experiencesRepository = new ExperienceRepository(); 
        // GET: Experiences
        public ActionResult Index()
        {
            var result = experiencesRepository.List();
            return View(result);
        }

        [HttpGet]
        public ActionResult ExperienceAdd()
        {

            return View();
        }

        [HttpPost]
        public ActionResult ExperienceAdd(Experience experience)
        {
            if (!ModelState.IsValid)
            {
                return View("ExperienceAdd");
            }
            experiencesRepository.TAdd(experience);
            return RedirectToAction("Index");
        }

        public ActionResult ExperienceDelete(int id)
        {
            Experience experience = experiencesRepository.Find(x => x.Id == id);
            experiencesRepository.TDelete(experience);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ExperienceUpdate(int id)
        {
            Experience experience = experiencesRepository.Find(x => x.Id == id);
            return View(experience);
        }

        [HttpPost]
        public ActionResult ExperienceUpdate(Experience experience)
        {
            Experience e = experiencesRepository.Find(x => x.Id == experience.Id);
            e.ExperienceName = experience.ExperienceName;
            e.ExperienceTwoTitle = experience.ExperienceTwoTitle;
            e.ExperienceDescription = experience.ExperienceDescription;
            e.ExperienceDate = experience.ExperienceDate;
            e.Image = experience.Image;
            experiencesRepository.TUpdate(e);
            return RedirectToAction("Index");
        }


    }
}