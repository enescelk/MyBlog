using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models.Entity;
using WebMVC.Repositories;

namespace WebMVC.Controllers
{
    public class OperationClaimsController : Controller
    {
        OperationClaimRepository operationClaimRepository = new OperationClaimRepository();
        // GET: OperationClaims
        public ActionResult Index()
        {
            var result = operationClaimRepository.List();
            return View(result);
        }

        [HttpGet]
        public ActionResult OperationClaimAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OperationClaimAdd(OperationClaim claim)
        {
            if (!ModelState.IsValid)
            {
                return View("OperationClaimAdd");
            }
            operationClaimRepository.TAdd(claim);
            return RedirectToAction("Index");
        }

        public ActionResult OperationClaimDelete(int id)
        {
            OperationClaim operation = operationClaimRepository.Find(c => c.Id == id);
            operationClaimRepository.TDelete(operation);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult OperationClaimUpdate(int id)
        {
            OperationClaim operation = operationClaimRepository.Find(c => c.Id == id);
            return View(operation);
        }

        [HttpPost]
        public ActionResult OperationClaimUpdate(OperationClaim operation)
        {
            OperationClaim claim = operationClaimRepository.Find(c => c.Id == operation.Id);
            claim.Id = operation.Id;
            claim.Name = operation.Name;
            operationClaimRepository.TUpdate(claim);
            return RedirectToAction("Index");
        }
    }
}