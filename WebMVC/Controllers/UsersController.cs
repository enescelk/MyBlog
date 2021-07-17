using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models.Entity;
using WebMVC.Repositories;

namespace WebMVC.Controllers
{
    public class UsersController : Controller
    {
        //private UserRepository _userRepository;
        //private NorthwindEntities _northwindEntities;

        //public UsersController(UserRepository userRepository,NorthwindEntities northwindEntities)
        //{
        //    _userRepository = userRepository;
        //    _northwindEntities = northwindEntities;
        //}

        UserRepository userRepository = new UserRepository();
        //NorthwindEntities northwindEntities = new NorthwindEntities();

        // GET: Users
        public ActionResult Index()
        {
            //northwindEntities.Users.Where(u => u.Status == true)
            var result = userRepository.List();
            return View(result);
        }

        public ActionResult UserDelete(int id)
        {
            User user = userRepository.Find(u => u.Id == id);
            userRepository.TDelete(user);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UserPassive(int id)
        {
            var passive = userRepository.Find(p => p.Id == id);
            passive.Status = false;
            userRepository.TUpdate(passive);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult UserPassive(User user)
        {
            User userr = userRepository.Find(use => use.Id == user.Id);
            userr.Status = false;
            userRepository.TUpdate(userr);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UserActive(int id)
        {
            var active = userRepository.Find(p => p.Id == id);
            active.Status = true;
            userRepository.TUpdate(active);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult UserActive(User user)
        {
            User userr = userRepository.Find(use => use.Id == user.Id);
            userr.Status = true;
            userRepository.TUpdate(userr);
            return RedirectToAction("Index");
        }


    }
}