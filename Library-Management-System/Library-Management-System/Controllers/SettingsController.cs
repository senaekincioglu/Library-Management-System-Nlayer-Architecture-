using Library_Management_System_BL;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library_Management_System_DAL.Entity;

namespace Library_Management_System.Controllers
{
    public class SettingsController : Controller
        
    {        // GET: Settings

    SettingsService service = new SettingsService();
        public ActionResult Index()
        {
            var users = service.GetSettings();
            return View(users);
        }
        public ActionResult Index2()
        {
            var users = service.GetSettings2();
            return View(users);
        }
        [HttpGet]
        public ActionResult NewAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewAdmin(Admin t)
        {
            service.AddSetting(t);
            return RedirectToAction("Index2");
        }
        public ActionResult DeleteAdmin(int id)
        {
           service.DeleteSetting(id);
            return RedirectToAction("Index2");
        }
        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            var admin = service.UpdateAdmin(id);
            return View("UpdateAdmin", admin);
        }
        [HttpPost]
        public ActionResult UpdateAdmin(Admin p)
        {

            service.UpdateAdmin(p);
            return RedirectToAction("Index2");
        }
    }

}