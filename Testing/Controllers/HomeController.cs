using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Testing.Models;

namespace Testing.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext db = new DatabaseContext();

        // GET: Books
        public ActionResult Index()
        {
            return View(db.books.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DatabaseContext.Books book)
        {
            if (ModelState.IsValid)
            {
                db.books.Add(book);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Edit(int id = 0)
        {
            Session["BookId"] = id;
            DatabaseContext.Books book = db.books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DatabaseContext.Books book)
        {
            book.BookId = (int)Session["BookId"];
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Delete(int id = 0)
        {
            DatabaseContext.Books book = db.books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id = 0)
        {
            DatabaseContext.Books book = db.books.Find(id);

            db.books.Remove(book);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public string details()
        {
            //List<string> list = new List<string>();
            return "Work in process";
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}