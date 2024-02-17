﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library_Management_System_DAL.Entity;
using Library_Management_System_BL;
using Microsoft.Ajax.Utilities;

namespace Library_Management_System.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        AuthorService service = new AuthorService();
        public ActionResult Index()
        {
            var degerler = service.GetAuthors();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult AddAuthor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAuthor(Author p) 
        { 
            if(!ModelState.IsValid)//eğer ki modelstate nin yani model üzerinde yapılmış olan geçerleme işlemi ünlemse yani false ise tekrar yazar ekle sayfasına geri döndürsün.
            {
                return View("AddAuthor"); 
            }
           service.AddAuthor(p);
            return RedirectToAction ("Index");
        }
        public ActionResult DeleteAuthor(int id)
        {
            service.DeleteAuthor(id);
            return RedirectToAction("Index");
        }

        public ActionResult BringAuthor(int id) 
        {
            var yzr=service.BringAuthor (id);
            return View("BringAuthor", yzr);
        }
        public ActionResult UpdateAuthor(Author p) 
        {
            service.UpdateAuthor(p);
            return RedirectToAction("Index");
        }
        public ActionResult AuthorBooks(int id) 
        {
          var author=service.AuthorBooks (id);
           
            return View(author);
        }
    }
}