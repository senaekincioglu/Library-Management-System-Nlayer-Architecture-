using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library_Management_System_DAL.Entity;
using Library_Management_System_BL;
using Microsoft.Ajax.Utilities;
using Library_Management_System_DAL;

namespace Library_Management_System.Controllers
{
    public class ProcessController : Controller
    {
        // GET: Process
        ProcessService service = new ProcessService();
        
        public ActionResult Index()
        {
            var deger = service.GetProcess();
            return View(deger); //durumu true olanları listele ve göster.
        }
    }
}