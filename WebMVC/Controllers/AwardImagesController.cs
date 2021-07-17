using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models.Entity;
using WebMVC.Repositories;

namespace WebMVC.Controllers
{
    public class AwardImagesController : Controller
    {
        AwardImageRepository awardImageRepository = new AwardImageRepository();
        // GET: AwardImages
        public ActionResult Index()
        {
            var result = awardImageRepository.List();
            return View(result);
        }

        [HttpGet]
        public ActionResult AwardImageAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AwardImageAdd(AwardImage awardImage)
        {
            awardImageRepository.TAdd(awardImage);
            return RedirectToAction("Index");
        }

        public ActionResult AwardImageDelete(int id)
        {
            AwardImage awardImage = awardImageRepository.Find(x => x.Id == id);
            awardImageRepository.TDelete(awardImage);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AwardImagePassive(int id)
        {
            var passive = awardImageRepository.Find(x => x.Id == id);
            passive.ImageStatus = false;
            awardImageRepository.TUpdate(passive);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult AwardImagePassive(AwardImage awardImage)
        {
            AwardImage image = awardImageRepository.Find(x => x.Id == awardImage.Id);
            image.ImageStatus = false;
            awardImageRepository.TUpdate(image);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AwardImageActive(int id)
        {
            var active = awardImageRepository.Find(p => p.Id == id);
            active.ImageStatus = true;
            awardImageRepository.TUpdate(active);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult AwardImageActive(AwardImage awardImage)
        {
            AwardImage image = awardImageRepository.Find(x => x.Id == awardImage.Id);
            image.ImageStatus = true;
            awardImageRepository.TUpdate(image);
            return RedirectToAction("Index");
        }
    }
}