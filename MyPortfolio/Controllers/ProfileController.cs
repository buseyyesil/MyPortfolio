using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ProfileController : Controller
    {
        MyPortfolioEntities db = new MyPortfolioEntities();
        [HttpGet]
        public ActionResult Index()
        {
            string email = Session["email"].ToString();
            if (String.IsNullOrEmpty(email))
            {
                return RedirectToAction("Index", "Login");
            }
            var admin = db.TblAdmins.FirstOrDefault(x => x.Email == email);
            return View(admin);
        }
        [HttpPost]
        public ActionResult Index(TblAdmin model)
        {
            string email = Session["email"].ToString();
            
            var admin=db.TblAdmins.FirstOrDefault(x=>x.Email==email);    
         
            if(admin.Password==model.Password)
            {
                if (model.ImageFile != null)
                {
                    var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;//proje yolu
                    var saveLocation = currentDirectory + "images\\";
                    var fileName = Path.Combine(saveLocation, model.ImageFile.FileName);
                    model.ImageFile.SaveAs(fileName);
                    admin.ImageURL = "/images/" + model.ImageFile.FileName;
                }

                admin.Name = model.Name;
                admin.Surname = model.Surname;
                admin.Email = model.Email;
                db.SaveChanges();
                Session.Abandon();
                return RedirectToAction("Index","Category");
       
            }
            ModelState.AddModelError("", "Girdiğiniz Şifre Hatalı");
            return View(model);


        }
    }
}

