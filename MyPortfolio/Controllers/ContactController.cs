using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        MyPortfolioEntities db = new MyPortfolioEntities();

        public ActionResult Index()
        {
            var contacts = db.TblContacts.ToList();
            return View(contacts);
        }

        public ActionResult Delete(int id)
        {
            var value = db.TblContacts.Find(id);
            db.TblContacts.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TblContact model)
        {
            if (ModelState.IsValid)
            {
                db.TblContacts.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var contact = db.TblContacts.Find(id);
            return View(contact);
        }

        [HttpPost]
        public ActionResult Update(TblContact model)
        {
            if (ModelState.IsValid)
            {
                var value = db.TblContacts.Find(model.ContactId);
                value.Phone = model.Phone;
                value.Email = model.Email;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}