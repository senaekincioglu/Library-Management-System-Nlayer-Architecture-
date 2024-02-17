using Library_Management_System_DAL.Dtos;
using Library_Management_System_DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Library_Management_System_DAL.Dtos;



namespace Library_Management_System_BL
{
    public class LoanedService
    {
        devrimme_senaEntities db = new devrimme_senaEntities();
        public List<Movement> GetPendingLoans()
        {
            return db.Movement.Where(x => x.TransactionStatus == false).ToList();
        }

        public List<SelectListItem> GetMembersAsSelectList()
        {
            return (from x in db.Member.ToList()
                    select new SelectListItem
                    {
                        Text = x.Name + " " + x.Surname,
                        Value = x.Id.ToString()
                    }).ToList();
        }

        public List<SelectListItem> GetBooksAsSelectList()
        {
            return (from y in db.Book.Where(x => x.Status == true).ToList()
                    select new SelectListItem
                    {
                        Text = y.Name,
                        Value = y.Id.ToString()
                    }).ToList();
        }

        public List<SelectListItem> GetEmployeesAsSelectList()
        {
            return (from z in db.Employee.ToList()
                    select new SelectListItem
                    {
                        Text = z.Employees,
                        Value = z.Id.ToString()
                    }).ToList();
        }

        public void LendBook(LoanedDto loanDto)
        {
            var member = db.Member.FirstOrDefault(x => x.Id == loanDto.MemberId);
            var book = db.Book.FirstOrDefault(y => y.Id == loanDto.BookId);
            var employee = db.Employee.FirstOrDefault(z => z.Id == loanDto.EmployeeId);

            if (member != null && book != null && employee != null)
            {
                Movement movement = new Movement
                {
                    Member = member,
                    Book = book,
                    Employee = employee,
                    // Diğer ödünç verme bilgileri
                };

                db.Movement.Add(movement);
                db.SaveChanges();
            }
        }

        public Movement GetLoanDetails(int id)
        {
            return db.Movement.Find(id);
        }

        public void UpdateLoan(Movement loan)
        {
            var existingLoan = db.Movement.Find(loan.Id);
            if (existingLoan != null)
            {
                existingLoan.BringMemberDate = loan.BringMemberDate;
                existingLoan.TransactionStatus = true;
                db.SaveChanges();
            }
        }
    }
}
