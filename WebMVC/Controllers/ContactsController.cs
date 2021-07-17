using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models.Entity;
using WebMVC.Repositories;

namespace WebMVC.Controllers
{
    public class ContactsController : Controller
    {
        ContactRepository contactRepository = new ContactRepository();
        // GET: Contacts
        public ActionResult Index()
        {
            var result = contactRepository.List();
            return View(result);
        }
        public ActionResult ContactDelete(int id)
        {
            Contact contact = contactRepository.Find(x => x.Id == id);
            contactRepository.TDelete(contact);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ContactUpdate(int id)
        {
            Contact contact = contactRepository.Find(x => x.Id == id);
            return View(contact);
        }
        [HttpPost]
        public ActionResult ContactUpdate(Contact contact)
        {
            Contact con = contactRepository.Find(x => x.Id == contact.Id);
            con.ContactFirstName = contact.ContactFirstName;
            con.ContactLastName = contact.ContactLastName;
            con.ContactEmail = contact.ContactEmail;
            con.ContactSubject = contact.ContactSubject;
            con.ContactDate = contact.ContactDate;
            con.ContactDescription = contact.ContactDescription;
            contactRepository.TUpdate(con);
            return RedirectToAction("Index");
        }
    }
}