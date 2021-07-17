using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models.Entity;
using WebMVC.Repositories;

namespace WebMVC.Controllers
{
    public class UserOperationClaimsController : Controller
    {
        UserOperationClaimRepository operationClimRepository = new UserOperationClaimRepository();
        // GET: UserOperationClaims
        public ActionResult Index()
        {
            var result = operationClimRepository.List();
            return View(result);
        }

        [HttpGet]
        public ActionResult UserOperationClaimAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserOperationClaimAdd(UserOperationClaim userOperationClaim)
        {
            if (!ModelState.IsValid)
            {
                return View("UserOperationClaimAdd");
            }
            operationClimRepository.TAdd(userOperationClaim);
            return RedirectToAction("Index");
        }

        public ActionResult UserOperationClaimDelete(int id)
        {
            UserOperationClaim userOperationClaim = operationClimRepository.Find(uoc => uoc.Id == id);
            operationClimRepository.TDelete(userOperationClaim);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UserOperationClaimUpdate(int id)
        {
            UserOperationClaim userOperationClaim = operationClimRepository.Find(uoc => uoc.Id == id);
            return View(userOperationClaim);
        }
        [HttpPost]
        public ActionResult UserOperationClaimUpdate(UserOperationClaim userOperationClaim)
        {
            UserOperationClaim user = operationClimRepository.Find(uoc => uoc.Id == userOperationClaim.Id);
            user.Id = userOperationClaim.Id;
            user.OperationClaimId = userOperationClaim.OperationClaimId;
            user.UserId = userOperationClaim.UserId;
            operationClimRepository.TUpdate(user);
            return RedirectToAction("Index");
        }
    }
}