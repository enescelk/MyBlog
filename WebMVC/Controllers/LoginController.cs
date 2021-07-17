using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMVC.Models.Entity;

namespace WebMVC.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Auhts

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Manager manager)
        {
            NorthwindEntities northwindEntities = new NorthwindEntities();
            var managers = northwindEntities.Managers.FirstOrDefault(m => m.AdminName == manager.AdminName && m.AdminPassword == manager.AdminPassword);
            if (managers != null)
            {
                FormsAuthentication.SetAuthCookie(managers.AdminName, false);
                Session["AdminName"] = managers.AdminName.ToString();
                return RedirectToAction("Index","Products");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index","Login");
        }
    }
}