using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class AdminLayoutController : Controller
    {
        MyPortfolioEntities db=new MyPortfolioEntities();
       
        public ActionResult Layout()
        {
            return View();
        }
        public PartialViewResult AdminLayoutRead()
        {
            return PartialView();
        }
        public PartialViewResult AdminLayoutHead()
        {
            return PartialView();
        }
        public PartialViewResult AdminLayoutSpinner()
        {
            return PartialView();
        }
        public PartialViewResult AdminLayoutSidebar()
        {

            try
            {
                if (Session["email"] != null)  // ← Session kontrolü ekle
                {
                    var email = Session["email"].ToString();
                    var admin = db.TblAdmins.FirstOrDefault(x => x.Email == email);

                    if (admin != null)
                    {
                        ViewBag.nameSurname = admin.Name + " " + admin.Surname;
                        ViewBag.image = admin.ImageURL;
                    }
                    else
                    {
                        ViewBag.nameSurname = "Admin";
                        ViewBag.image = "/images/default.png";
                    }
                }
                else
                {
                    ViewBag.nameSurname = "Admin";
                    ViewBag.image = "/images/default.png";
                }
            }
            catch (Exception)
            {
                ViewBag.nameSurname = "Admin";
                ViewBag.image = "/images/default.png";
            }

            return PartialView();
        }
        public PartialViewResult AdminLayoutNavbar()
        {
            try
            {
                if (Session["email"] != null)  // ← Session kontrolü ekle
                {
                    var email = Session["email"].ToString();
                    var admin = db.TblAdmins.FirstOrDefault(x => x.Email == email);

                    if (admin != null)
                    {
                        ViewBag.nameSurname = admin.Name + " " + admin.Surname;
                        ViewBag.image = admin.ImageURL;
                    }
                    else
                    {
                        ViewBag.nameSurname = "Admin";
                        ViewBag.image = "/images/default.png";
                    }
                }
                else
                {
                    ViewBag.nameSurname = "Admin";
                    ViewBag.image = "/images/default.png";
                }
            }
            catch (Exception)
            {
                ViewBag.nameSurname = "Admin";
                ViewBag.image = "/images/default.png";
            }
            // Mesajları getir
            var messages = db.TblMessages.Where(x => x.IsRead == false).Take(3).ToList();
            ViewBag.Messages = messages;

            return PartialView();
        }
        public ActionResult AdminLayoutFooter()
        {
            return PartialView();
        }
        public PartialViewResult AdminLayoutScripts()
        {
            return PartialView();
        }

    }
}