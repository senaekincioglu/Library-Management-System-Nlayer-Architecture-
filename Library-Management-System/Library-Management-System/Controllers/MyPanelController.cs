using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library_Management_System_DAL.Entity;
using Library_Management_System_BL;
using Library_Management_System_DAL;
using System.Web.Security;

namespace Library_Management_System.Controllers
{
    [Authorize]//burda yazınca bu sayfaya ait hepsini kapsar.
    public class MyPanelController : Controller
    {

        // GET: MyPanel

        MyPanelService service = new MyPanelService();
        [HttpGet]
        public ActionResult Index()
        {
            var userEmail = (string)Session["Mail"];
            var panelData = service.GetPanelData(userEmail);

            ViewBag.d1 = panelData.Name;
            ViewBag.d2 = panelData.Surname;
            ViewBag.d3 = panelData.Photograph;
            ViewBag.d4 = panelData.UserName;
            ViewBag.d5 = panelData.School;
            ViewBag.d6 = panelData.Telephone;
            ViewBag.d7 = panelData.Mail;
            ViewBag.d8 = panelData.MemberId;
            ViewBag.d9 = panelData.MovementCount;
            ViewBag.d10 = panelData.MessageCount;

            return View(panelData.Announcements);
        }

        [HttpPost]
        public ActionResult Index2(Member p)
        {
            service.UpdateMemberInfo(p);
            return RedirectToAction("Index");
        }

        public ActionResult MyBooks()
        {
            var userEmail = (string)Session["Mail"];
            var books = service.GetMemberBooks(userEmail);
            return View(books);
        }

        public ActionResult Announcements()
        {
            var announcementList = service.GetPanelData((string)Session["Mail"]).Announcements;
            return View(announcementList);
        }

        public ActionResult LogOut()
        {
            System.Web.Security.FormsAuthentication.SignOut();
            return RedirectToAction("LogIn", "Login");
        }

        public PartialViewResult Partial1()
        {
            return PartialView();
        }

        public PartialViewResult Partial2()
        {
            var kullanici = (string)Session["Mail"];
            var findmember = service.GetMember(kullanici);
            return PartialView("Partial2", findmember);
        }
    }
}