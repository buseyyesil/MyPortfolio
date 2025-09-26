using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {

        MyPortfolioEntities db = new MyPortfolioEntities();
       
        public ActionResult Index()
        {
            var values = db.TblCategories.ToList();//listeleme demek tolist
            return View(values);
        }

        [HttpGet]//button gelir fakat buttona tıklayınca çalışmaz onu post yapıyor

        public ActionResult CreateCategory()
        {
             return View();
        }

        [HttpPost]

        public ActionResult CreateCategory(TblCategory category)
        {
            db.TblCategories.Add(category); 
            db.SaveChanges();   
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCategory(int id)//butona tıklayınca tetiklenecek bir index olmayacak
        {
            var value=db.TblCategories.Find(id);
            db.TblCategories.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");   
        }
        [HttpGet]

        public ActionResult UpdateCategory(int id)
        {
            var value = db.TblCategories.Find(id);
            return View(value);
        }

        [HttpPost]

        public ActionResult UpdateCategory(TblCategory model)
        {
            var value = db.TblCategories.Find(model.CategoryId);
            value.Name = model.Name;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
