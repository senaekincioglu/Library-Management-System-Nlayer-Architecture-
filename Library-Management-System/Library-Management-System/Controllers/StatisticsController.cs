using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library_Management_System_DAL.Entity;
using Library_Management_System_BL;
using Library_Management_System_DAL;
using Library_Management_System_DAL;


namespace Library_Management_System.Controllers
{
    public class StatisticsController : Controller
    {
        StatisticService service = new StatisticService(); 
        // GET: Statistics
        public ActionResult Index()
        {
            var statics=service.GetStatistic();
            ViewBag.Dgr1 = statics.Deger1;
            ViewBag.Dgr2 = statics.Deger2;
            ViewBag.Dgr3 = statics.Deger3;
            ViewBag.Dgr4 = statics.Deger4;
            return View();
        }
        public ActionResult Weather()
        {
            return View();  
        }
        public ActionResult WeatherCard()
        {
            return View();  
        }
        public ActionResult Gallery()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadPicture(HttpPostedFileBase dosya) //dosya yükleme kontrolüdür.
        {
            if(dosya.ContentLength>0)
            {
                string dosyayolu = Path.Combine(Server.MapPath("~/web2/resimler/"), Path.GetFileName(dosya.FileName));
                dosya.SaveAs(dosyayolu);
            }
            return RedirectToAction("Gallery");
        }
        public ActionResult LinqCard()
        {
            var service = new StatisticService();
            var data = service.GetLinqCardData();

            ViewBag.dgr1 = data.Deger1;
            ViewBag.dgr2 = data.Deger2;
            ViewBag.dgr3 = data.Deger3;
            ViewBag.dgr4 = data.Deger4;
            ViewBag.dgr5 = data.Deger5;
            ViewBag.dgr8 = data.Deger8;
            ViewBag.dgr9 = data.Deger9;
            ViewBag.dgr11 = data.Deger11;

            return View();
        }

    }
}