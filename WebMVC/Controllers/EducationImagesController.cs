using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models.Entity;
using WebMVC.Repositories;

namespace WebMVC.Controllers
{
    public class EducationImagesController : Controller
    {
        EducationImagesRepository educationImagesRepository = new EducationImagesRepository(); 
        // GET: EducationImages
        public ActionResult Index()
        {
            var result = educationImagesRepository.List();
            return View(result);
        }

        [HttpGet]
        public ActionResult EducationImageAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EducationImageAdd(EducationImage educationImage)
        {
            educationImagesRepository.TAdd(educationImage);
            return RedirectToAction("Index");
        }

        public ActionResult EducationImageDelete(int id)
        {
            EducationImage educationImage = educationImagesRepository.Find(x => x.Id == id);
            educationImagesRepository.TDelete(educationImage);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EducationImagePassive(int id)
        {
            var passive = educationImagesRepository.Find(x => x.Id == id);
            passive.ImageStatus = false;
            educationImagesRepository.TUpdate(passive);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult EducationImagePassive(EducationImage educationImage)
        {
            EducationImage image = educationImagesRepository.Find(x => x.Id == educationImage.Id);
            image.ImageStatus = false;
            educationImagesRepository.TUpdate(image);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EducationImageActive(int id)
        {
            var active = educationImagesRepository.Find(p => p.Id == id);
            active.ImageStatus = true;
            educationImagesRepository.TUpdate(active);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult EducationImageActive(EducationImage educationImage)
        {
            EducationImage image = educationImagesRepository.Find(x => x.Id == educationImage.Id);
            image.ImageStatus = true;
            educationImagesRepository.TUpdate(image);
            return RedirectToAction("Index");
        }
    }
}