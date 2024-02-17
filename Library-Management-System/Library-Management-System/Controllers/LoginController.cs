using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;//bu kütüphane de yeni tanımlandı
using Library_Management_System_DAL;
using Library_Management_System_DAL.Entity;
using Library_Management_System_DAL.Dtos;
using Library_Management_System_BL;

namespace Library_Management_System.Controllers
{
    [AllowAnonymous]//bu komutla global daki yaptığın işlem ile birlikte giriş yapma işlemi muaf tutulacak.
    public class LoginController : Controller
    {
        // GET: Login
        LoginService service= new LoginService();
       
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(Member p)//giriş işleminde kullanıcı adı ve şifreyi kontrol ediyor.
        {
            if (ModelState.IsValid)
            {
                if (service.Login(p))
                {
                    FormsAuthentication.SetAuthCookie(p.Mail, false);
                    Session["Mail"] = p.Mail.ToString();
                    return RedirectToAction("Index", "MyPanel");
                }
            }
            return View();
        }
    }
}