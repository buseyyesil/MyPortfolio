using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class AboutController : Controller
    {
        MyPortfolioEntities db = new MyPortfolioEntities();

        public ActionResult Index()
        {
            var about = db.TblAbouts.ToList();
            return View(about);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var about = db.TblAbouts.Find(id);
            return View(about);
        }

        [HttpPost]
        public ActionResult Update(TblAbout model)
        {
            var value = db.TblAbouts.Find(model.AboutId);
            if (ModelState.IsValid)
            {
                // ImageFile işlemi
                if (model.ImageFile != null)
                {
                    var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    var saveLocation = currentDirectory + "images\\";
                    var fileName = Path.Combine(saveLocation, model.ImageFile.FileName);
                    model.ImageFile.SaveAs(fileName);
                    value.ImageUrl = "/images/" + model.ImageFile.FileName;
                }

                // CV dosyası işlemi
                if (model.CvFile != null)
                {
                    var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    var cvSaveLocation = currentDirectory + "cv\\";
                    if (!Directory.Exists(cvSaveLocation))
                    {
                        Directory.CreateDirectory(cvSaveLocation);
                    }
                    var cvFileName = Path.Combine(cvSaveLocation, model.CvFile.FileName);
                    model.CvFile.SaveAs(cvFileName);
                    value.CvUrl = "/cv/" + model.CvFile.FileName;
                }

                // Güncellenen değerleri kaydet
                value.Title = model.Title;
                value.Description = model.Description;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // Delete işlemi (isteğe bağlı)
        public ActionResult Delete(int id)
        {
            var value = db.TblAbouts.Find(id);
            db.TblAbouts.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}