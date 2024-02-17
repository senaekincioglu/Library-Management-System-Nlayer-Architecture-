using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library_Management_System_DAL.Entity;
using Library_Management_System_BL;


namespace Library_Management_System.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeService service = new EmployeService();
        
        // GET: Employee
        public ActionResult Index()
        {
            var degerler = service.GetEmploye();
            return View(degerler);
            
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee p) 
        {
            if(!ModelState.IsValid) //eğer boşsa bunu yapıyor.
            {
                return View("AddEmployee");
            }
            service.AddEmploye(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteEmployee(int id) 
        {
            service.DeleteEmploye(id);
            return RedirectToAction("Index");
        }
        public ActionResult BringEmployee(int id) 
        {
            var prs = service.BringEmployee(id);
            return View("BringEmployee", prs);
        }
        public ActionResult UpdateEmployee(Employee p)
        {
            service.UpdateEmployee(p);
            return RedirectToAction("Index");
        }
    }
}