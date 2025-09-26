using MyPortfolio.Models;
using System.Linq;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    [Authorize]
    public class TestimonialController : Controller
    {
        MyPortfolioEntities db = new MyPortfolioEntities();

        public ActionResult Index()
        {
            var values = db.TblTestimonials.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TblTestimonial model)
        {
            db.TblTestimonials.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var value = db.TblTestimonials.Find(id);
            db.TblTestimonials.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var testimonial = db.TblTestimonials.Find(id);
            return View(testimonial);
        }

        [HttpPost]
        public ActionResult Update(TblTestimonial model)
        {
            var value = db.TblTestimonials.Find(model.TestimonialId);
            value.NameSurname = model.NameSurname;
            value.Title = model.Title;
            value.Comment = model.Comment;
            value.ImageUrl = model.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}