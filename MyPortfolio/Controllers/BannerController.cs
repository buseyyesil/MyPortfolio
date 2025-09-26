using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    [Authorize]
    public class BannerController : Controller
    {
        MyPortfolioEntities db = new MyPortfolioEntities();

        public ActionResult Index()
        {
            var values = db.TblBanners.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TblBanner banner_model)
        {
            db.TblBanners.Add(banner_model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var value = db.TblBanners.Find(id);
            db.TblBanners.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var banner = db.TblBanners.Find(id);
            return View(banner);
        }

        [HttpPost]
        public ActionResult Update(TblBanner model)
        {
            var value = db.TblBanners.Find(model.BannerId);
            value.Title = model.Title;
            value.Description = model.Description;
            value.IsShown = model.IsShown;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}