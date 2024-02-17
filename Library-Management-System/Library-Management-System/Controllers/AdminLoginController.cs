using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Library_Management_System_BL;
using Library_Management_System_DAL.Entity;

namespace Library_Management_System.Controllers
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        AdminLoginService service = new AdminLoginService();
        public ActionResult Login()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Login(Admin p)
        {
            var informations =service.Login(p.UserName, p.Password);
            if(informations!=null)
            {
                FormsAuthentication.SetAuthCookie(informations.UserName, false);
                Session["UserName"] = informations.UserName.ToString();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return View();
            }
        }
           
    }
}