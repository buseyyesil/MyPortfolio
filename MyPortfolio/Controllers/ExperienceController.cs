using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    [Authorize]
    public class ExperienceController : Controller
    {
        MyPortfolioEntities db = new MyPortfolioEntities();

        public ActionResult Index()
        {
            var experiences = db.TblExperiences.OrderByDescending(x => x.StarDate).ToList();
            return View(experiences);
        }

        public ActionResult Delete(int id)
        {
            var value = db.TblExperiences.Find(id);
            db.TblExperiences.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TblExperience model)
        {
            db.TblExperiences.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var experience = db.TblExperiences.Find(id);
            return View(experience);
        }

        [HttpPost]
        public ActionResult Update(TblExperience model)
        {
            var value = db.TblExperiences.Find(model.ExperienceId);
            value.CompanyName = model.CompanyName;
            value.Title = model.Title;
            value.Description = model.Description;
            value.StarDate = model.StarDate;
            value.EndDate = model.EndDate;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}