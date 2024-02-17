using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library_Management_System_DAL.Entity;
using Library_Management_System_BL;
using Library_Management_System_DAL;

namespace Library_Management_System.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        // GET: Register
        
        RegisterService service = new RegisterService();
        [HttpGet]
        public ActionResult Record()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Record(Member p)
        {
            if(!ModelState.IsValid)
            {
                return View("Record");
            }
            service.MemberS(p);
            return View();
        }
    }
}