using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library_Management_System_DAL.Entity;
using Library_Management_System_DAL.Dtos;
using Library_Management_System_BL;

namespace Library_Management_System.Controllers
{
    [AllowAnonymous]
    public class ShowCaseController : Controller
    {
        // GET: ShowCase
        ShowCaseService service = new ShowCaseService();

        [HttpGet]
        public ActionResult Index()
        {
            IndexDto cs = service.GetIndexDto();
            return View(cs);
        }
        [HttpPost]
        public ActionResult Index(Contact t)
        {
            service.AddContact(t);
            return RedirectToAction("Index");
        }
    }
}