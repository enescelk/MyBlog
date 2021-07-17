using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models.Entity;
using WebMVC.Repositories;

namespace WebMVC.Controllers
{
    public class AboutImagesController : Controller
    {
        AboutImageRepository aboutImageRepositroy = new AboutImageRepository();
        // GET: AboutImages
        public ActionResult Index()
        {
            var result = aboutImageRepositroy.List();
            return View(result);
        }

        [HttpGet]
        public ActionResult AboutImageAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AboutImageAdd(AboutImage aboutImage)
        {
            aboutImageRepositroy.TAdd(aboutImage);
            return RedirectToAction("Index");
        }

        public ActionResult AboutImageDelete(int id)
        {
            AboutImage aboutImage = aboutImageRepositroy.Find(x => x.Id == id);
            aboutImageRepositroy.TDelete(aboutImage);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AboutImagePassive(int id)
        {
            var passive = aboutImageRepositroy.Find(x => x.Id == id);
            passive.ImageStatus = false;
            aboutImageRepositroy.TUpdate(passive);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult AboutImagePassive(AboutImage aboutImage)
        {
            AboutImage image = aboutImageRepositroy.Find(x => x.Id == aboutImage.Id);
            image.ImageStatus = false;
            aboutImageRepositroy.TUpdate(image);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AboutImageActive(int id)
        {
            var active = aboutImageRepositroy.Find(p => p.Id == id);
            active.ImageStatus = true;
            aboutImageRepositroy.TUpdate(active);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult AboutImageActive(AboutImage aboutImage)
        {
            AboutImage image = aboutImageRepositroy.Find(x => x.Id == aboutImage.Id);
            image.ImageStatus = true;
            aboutImageRepositroy.TUpdate(image);
            return RedirectToAction("Index");
        }

    }
}