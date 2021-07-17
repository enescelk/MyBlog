using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models.Entity;
using WebMVC.Repositories;

namespace WebMVC.Controllers
{
    public class EducationsController : Controller
    {
        EducationRepository educationRepository = new EducationRepository();

        // GET: Education
        public ActionResult Index()
        {
            var result = educationRepository.List();
            return View(result);
        }

        [HttpGet]
        public ActionResult EducationAdd()
        {

            return View();
        }

        [HttpPost]
        public ActionResult EducationAdd(Education education)
        {
            if (!ModelState.IsValid)
            {
                return View("EducationAdd");
            }
            educationRepository.TAdd(education);
            return RedirectToAction("Index");
        }

        public ActionResult EducationDelete(int id)
        {
            Education education = educationRepository.Find(x => x.Id == id);
            educationRepository.TDelete(education);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EducationUpdate(int id)
        {
            Education education = educationRepository.Find(x => x.Id == id);
            return View(education);
        }

        [HttpPost]
        public ActionResult EducationUpdate(Education education)
        {
            Education e = educationRepository.Find(x => x.Id == education.Id);
            e.SchoolDate = education.SchoolDate;
            e.SchoolDescription = education.SchoolDescription;
            e.SchoolName = education.SchoolName;
            e.SchoolTitle = education.SchoolTitle;
            e.GPA = education.GPA;
            educationRepository.TUpdate(e);
            return RedirectToAction("Index");
        }
    }
}