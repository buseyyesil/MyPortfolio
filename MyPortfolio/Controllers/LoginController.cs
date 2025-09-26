using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyPortfolio.Controllers
{
    [AllowAnonymous]//herkes buraya erişebilir demek
    public class LoginController : Controller
    {
       
        MyPortfolioEntities db=new MyPortfolioEntities();

        [HttpGet]
        
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]  
        public ActionResult Index(TblAdmin model)
        {
            var value = db.TblAdmins.FirstOrDefault(x=>x.Email==model.Email && x.Password==model.Password);
            if (value == null)
            {
                ModelState.AddModelError("", "Email veya Şifre hatalı");
                return View(model);
            }
            FormsAuthentication.SetAuthCookie(value.Email, false);

            Session["email"] = value.Email;
            return RedirectToAction("index", "category");
           
           
        }
    }
}