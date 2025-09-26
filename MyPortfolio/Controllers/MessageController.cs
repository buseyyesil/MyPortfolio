using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyPortfolio.Models;

namespace MyPortfolio.Controllers
{
    public class MessageController : Controller
    {
        MyPortfolioEntities db=new MyPortfolioEntities(); //sqlde ki db adım bu 
        
        public ActionResult Index()
        {
            var values=db.TblMessages.Where(n=>n.IsRead==false).ToList(); 
            return View(values);
        }
        public ActionResult MessageDetail(int id)
        {
            var value = db.TblMessages.Find(id);
            value.IsRead = true;
            db.SaveChanges();
            return View(value);
        }
        [HttpPost]
        public ActionResult MakeMessageRead(int id)
        {
            var value = db.TblMessages.Find(id);
            value.IsRead = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // Okunan mesajlar
        public ActionResult ReadMessages()
        {
            var values = db.TblMessages.Where(n => n.IsRead == true).ToList();
            return View(values);
        }


    }
}