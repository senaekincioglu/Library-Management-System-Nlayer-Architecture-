using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library_Management_System_DAL.Entity;
using Library_Management_System_BL;
using Library_Management_System_DAL.Dtos;

namespace Library_Management_System.Controllers
{
    public class LoanedController : Controller
    {
        // GET: Loaned
        LoanedService service = new LoanedService();
        public ActionResult Index()
        {
            var pendingLoans = service.GetPendingLoans();
            return View(pendingLoans);
        }

        [HttpGet]
        public ActionResult LendMe()
        {
            var members = service.GetMembersAsSelectList();
            var books = service.GetBooksAsSelectList();
            var employees = service.GetEmployeesAsSelectList();


            ViewBag.dgr1 = members;
            ViewBag.dgr2 = books;
            ViewBag.dgr3 = employees;

            return View();
        }

        [HttpPost]
        public ActionResult LendMe(Movement p)
        {
            // Movement nesnesinden uygun özellikleri LoanedDto'ya kopyala
            LoanedDto loanDto = new LoanedDto
            {
                MemberId = p.MemberId,
                BookId = p.BookId,
                EmployeeId = p.EmployeeId
                // Gerekirse diğer özellikler de kopyalanabilir
            };

            // Daha sonra LoanedDto nesnesini kullanarak LendBook metodunu çağır
            service.LendBook(loanDto);
            return RedirectToAction("Index");
        }

        public ActionResult LoanReturn(int id)
        {
            var loanDetails = service.GetLoanDetails(id);
            // Diğer işlemler
            return View(loanDetails);
        }

        [HttpPost]
        public ActionResult LoanUpdate(Movement p)
        {
            service.UpdateLoan(p);
            return RedirectToAction("Index");
        }

    }
}