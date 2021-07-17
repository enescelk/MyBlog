using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models.Entity;
using WebMVC.Repositories;

namespace WebMVC.Controllers
{
    public class CategoriesController : Controller
    {

        CategoryRepository categoryRepository = new CategoryRepository();

        // GET: Categories
        public ActionResult Index()
        {
            var result = categoryRepository.List();
            return View(result);
        }

        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoryAdd(Category category)
        {
            categoryRepository.TAdd(category);
            return RedirectToAction("Index");
        }

        public ActionResult CategoryDelete(int id)
        {
            Category category = categoryRepository.Find(c => c.CategoryID == id);
            categoryRepository.TDelete(category);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CategoryUpdate(int id)
        {
            Category category = categoryRepository.Find(c => c.CategoryID == id);
            return View(category);
        }
        [HttpPost]
        public ActionResult CategoryUpdate(Category category)
        {
            Category c = categoryRepository.Find(x => x.CategoryID == category.CategoryID);
            c.CategoryName = category.CategoryName;
            c.Description = category.Description;
            categoryRepository.TUpdate(c);
            return RedirectToAction("Index");
        }
    }
}

