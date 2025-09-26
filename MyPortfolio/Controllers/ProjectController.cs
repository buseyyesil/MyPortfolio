using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;

namespace MyPortfolio.Controllers
{
    public class ProjectController : Controller
    {
        MyPortfolioEntities db = new MyPortfolioEntities();

        private void CategoryDropDown() //VOİD GERİYE DEĞER DÖNDÜRMÜYOR
        {
            var categoryList = db.TblCategories.ToList();
            List<SelectListItem> categories = (from x in categoryList
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.CategoryId.ToString()


                                               }).ToList();
            ViewBag.categories = categories;
        }

        public ActionResult Index()
        {
            var projects = db.TblProjects.ToList();
            return View(projects);
        }
    
       [HttpGet]
        public ActionResult CreateProject()
            
        {
            CategoryDropDown();
            return View();  
        }
        [HttpPost]
        public ActionResult CreateProject(TblProject model)
        {


            var categoryList = db.TblCategories.ToList();
            List<SelectListItem> categories = (from x in categoryList
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.CategoryId.ToString()

                                               }).ToList();
            ViewBag.categories = categories;

            if (!ModelState.IsValid)

            {
                return View(model);

            }

            db.TblProjects.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult DeleteProject(int id)
        {
            var value = db.TblProjects.Find(id);
            db.TblProjects.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]

        public ActionResult UpdateProject(int id)
        {
            CategoryDropDown();
            var value=db.TblProjects.Find(id);
            return View(value);
        }

        [HttpPost]

        public ActionResult UpdateProject(TblProject model)
        {
            CategoryDropDown();
            var value=db.TblProjects.Find(model.ProjectId);
            value.Name = model.Name;
            value.ImageUrl = model.ImageUrl;
            value.Description = model.Description;
            value.CategoryId = model.CategoryId;
            value.GitHubUrl = model.GitHubUrl;
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            db.SaveChanges();
            return RedirectToAction("Index"); 
        }

    }
}