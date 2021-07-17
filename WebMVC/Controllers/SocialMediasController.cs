using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models.Entity;
using WebMVC.Repositories;

namespace WebMVC.Controllers
{
    public class SocialMediasController : Controller
    {

        SocialMediaRepository socialMediaRepo = new SocialMediaRepository();

        // GET: SocialMedias
        public ActionResult Index()
        {
            var result = socialMediaRepo.List();
            return View(result);
        }

        [HttpGet]
        public ActionResult MediaAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MediaAdd(SocialMedia media)
        {
            if (!ModelState.IsValid)
            {
                return View("ManagerAdd");
            }
            socialMediaRepo.TAdd(media);
            return RedirectToAction("Index");
        }

        public ActionResult MediaDelete(int id)
        {
            SocialMedia media = socialMediaRepo.Find(m => m.Id == id);
            socialMediaRepo.TDelete(media);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult MediaUpdate(int id)
        {
            SocialMedia media = socialMediaRepo.Find(m => m.Id == id);
            return View(media);
        }

        [HttpPost]
        public ActionResult MediaUpdate(SocialMedia socialMedia)
        {
            SocialMedia media = socialMediaRepo.Find(m => m.Id == socialMedia.Id);
            media.IconName = socialMedia.IconName;
            media.MediaLink = socialMedia.MediaLink;
            socialMediaRepo.TUpdate(media);
            return RedirectToAction("Index");
        }
    }
}