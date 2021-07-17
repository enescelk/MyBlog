                                                                                                                                                    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models.Entity;
using WebMVC.Repositories;

namespace WebMVC.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {

        ProductRepository productRepository = new ProductRepository();

        // GET: Products
        public ActionResult Index()
        {
            var result = productRepository.List();
            return View(result);
        }

        [HttpGet]
        public ActionResult ProductAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ProductAdd(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View("ProductAdd");
            }
            productRepository.TAdd(product);
            return RedirectToAction("Index");
        }

        public ActionResult ProductDelete(int id)
        {
            Product product = productRepository.Find(p => p.ProductID == id);
            productRepository.TDelete(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ProductUpdate(int id)
        {
            Product product = productRepository.Find(p => p.ProductID == id);
            return View(product);
        }

        [HttpPost]
        public ActionResult ProductUpdate(Product product)
        {
            Product p = productRepository.Find(x => x.ProductID == product.ProductID);
            p.ProductName = product.ProductName;
            p.CategoryID = product.CategoryID;
            p.UnitPrice = product.UnitPrice;
            p.UnitsInStock = product.UnitsInStock;
            productRepository.TUpdate(p);
            return RedirectToAction("Index");
        }

    }
}