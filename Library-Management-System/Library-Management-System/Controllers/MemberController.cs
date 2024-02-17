using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library_Management_System_DAL.Entity;
using Library_Management_System_BL;
using PagedList;
using PagedList.Mvc;


namespace Library_Management_System.Controllers
{
    public class MemberController : Controller
    {
        MemberService service = new MemberService();
        // GET: Member
        public ActionResult Index(int sayfa = 1)
        {
            //var degerler = db.Member.ToList();
            var degerler = service.GetMember();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult AddMember()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddMember(Member p)
        {
            if (!ModelState.IsValid) //eğer boşsa bunu yapıyor.
            {
                return View("AddMember");
            }
            service.AddMember(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteMember(int id) 
        {
            service.DeleteMember(id);
            return RedirectToAction("Index");
        }
        public ActionResult BringMember(int id)
        {
            var uye = service.BringMember(id);
            return View("BringMember", uye);
        }
        public ActionResult UpdateMember(Member p)
        {
            service.UpdateMember(p);
            return RedirectToAction("Index");
        }
        public ActionResult MemberBookHistory(int id)
        {
            var memberBookHistory = service.GetMemberBookHistory(id);
            ViewBag.u1 = memberBookHistory.MemberName;

            return View(memberBookHistory.BookHistory);
        }
    }


    }


