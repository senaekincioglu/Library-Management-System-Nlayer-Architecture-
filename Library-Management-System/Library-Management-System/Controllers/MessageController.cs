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
    public class MessageController : Controller
    {
        // GET: Message
       
        MessageService service = new MessageService();
        public ActionResult Index()
        {
            var memberMail = (string)Session["Mail"].ToString();
            var message = service.GetIncomingMessages(memberMail);//listelesin ama gelen mesajları.
            return View(message);
        }
        public ActionResult Outgoing()
        {
            var membermail = (string)Session["Mail"].ToString();//maile gelenler yani mail kısmına.
            var message = service.GetOutgoingMessages(membermail);//listelesin ama gelen mesajları.
            return View(message);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message t)
        {
            var membermail = (string)Session["Mail"].ToString();
            t.Sender = membermail;
            t.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            service.SendMessage(t);
            return RedirectToAction("Outgoing", "Message");
        }
        public PartialViewResult Partial1()
        {
            var memberMail = (string)Session["Mail"].ToString();
            var messagers=service.GetMessageStatistics(memberMail);

            ViewBag.d1=messagers.NumberOfIncomingMessages;
            ViewBag.d2 = messagers.NumberOfOutgoingMessages;
            return PartialView();
        }
    }
}