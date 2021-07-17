using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models.Entity;
using WebMVC.Repositories;

namespace WebMVC.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        NorthwindEntities entities = new NorthwindEntities();
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult About()
        {
            var result = entities.Abouts.ToList();
            return PartialView(result);
        }

        public PartialViewResult AboutSection()
        {
            var result = entities.AboutImages.ToList();
            return PartialView(result);
        }

        public PartialViewResult SocialMedia()
        {
            var result = entities.SocialMedias.ToList();
            return PartialView(result);
        }

        public PartialViewResult Experience()
        {
            var result = entities.Experiences.ToList();
            return PartialView(result);
        }

        public PartialViewResult EducationSection()
        {
            var result = entities.EducationImages.ToList();
            return PartialView(result);
        }

        public PartialViewResult Education()
        {
            var result = entities.Educations.ToList();
            return PartialView(result);
        }

        public PartialViewResult Skils()
        {
            var result = entities.Skils.ToList();
            return PartialView(result);
        }

        public PartialViewResult Interests()
        {
            var result = entities.Interests.ToList();
            return PartialView(result);
        }

        public PartialViewResult AwardSection()
        {
            var result = entities.AwardImages.ToList();
            return PartialView(result);
        }

        public PartialViewResult Awards()
        {
            var result = entities.Awards.ToList();
            return PartialView(result);
        }

        [HttpGet]
        public PartialViewResult ContactAdd()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult ContactAdd(Contact contact)
        {
            contact.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            entities.Contacts.Add(contact);
            entities.SaveChanges();
            return PartialView();
        }

    }
}