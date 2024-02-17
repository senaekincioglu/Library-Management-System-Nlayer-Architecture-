using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library_Management_System_DAL.Entity;
using Library_Management_System_BL;
using Microsoft.Ajax.Utilities;

using SelectListItem = System.Web.Mvc.SelectListItem;

namespace Library_Management_System.Controllers
{
    public class BookController : Controller
    {
        BookService service = new BookService();
       
        public ActionResult Index(string p)

        {

            var kitaplar = service.GetBook(p);

            return View(kitaplar);
        }
        [HttpGet]
        public ActionResult AddBook()
        {

            var categories = new List<SelectListItem>();
            service.GetCategories().ForEach(x => categories.Add(new SelectListItem { Text = x.Text, Value = x.Value }));
            ViewBag.dgr1 = categories;


            var authors = new List<SelectListItem>();
            service.GetAuthors().ForEach(x => authors.Add(new SelectListItem { Text = x.Text, Value = x.Value }));
            ViewBag.dgr2 = authors;

            return View();
        }
        [HttpPost]
        public ActionResult AddBook(Book p)
        {
            service.AddBook(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteBook(int id)
        {
            service.DeleteBook(id);
            return RedirectToAction("Index");  
        }
        public ActionResult BringBook(int id) 
        {
            var ktp=service.BringBook(id);
            var categories = new List<SelectListItem>();
            service.GetCategories().ForEach(x => categories.Add(new SelectListItem { Text = x.Text, Value = x.Value }));
            ViewBag.dgr1 = categories;


            var authors = new List<SelectListItem>();
            service.GetAuthors().ForEach(x => authors.Add(new SelectListItem { Text = x.Text, Value = x.Value }));
            ViewBag.dgr2 = authors;
            return View("BringBook",ktp);//id ye göre getir demek.
        }
        public ActionResult UpdateBook(Book p)
        {
            service.UpdateBook(p);
            return RedirectToAction("Index");

        }
    }
}