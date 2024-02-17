using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library_Management_System_DAL.Entity;
using Library_Management_System_BL;
using Microsoft.Ajax.Utilities;

namespace Library_Management_System.Controllers
{
    public class AnnouncementController : Controller
    {
        // GET: Announcement
        AnnouncementService service = new AnnouncementService();
        public ActionResult Index()
        {
            var degerler = service.GetAnnouncements();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult NewAnnouncement()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewAnnouncement(Announcements t)
        {
            service.AddAnnouncement(t);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAnnouncement(int id)
        {
            var announcement = service.DeleteAnnouncement(id);
            return RedirectToAction("Index");
        }
        public ActionResult AnnouncementDetail(Announcements p)
        {
            var announcement = service.AnnouncementDetail(p);
            return View("AnnouncementDetail", announcement);
        }
        public ActionResult UpdateAnnouncement(Announcements t)
        {
            service.UpdateAnnouncement(t);
            return RedirectToAction("Index");
        }

    }
}