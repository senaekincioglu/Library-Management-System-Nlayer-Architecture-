using Library_Management_System_DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Library_Management_System_BL;
using PagedList;
using PagedList.Mvc;
using Library_Management_System.Models;


namespace Library_Management_System_BL
{
    public class EmployeService
    {
        devrimme_senaEntities db = new devrimme_senaEntities();
        public IEnumerable<Employee> GetEmploye()
        {
            var degerler = db.Employee.ToList();
            return degerler;
        }

        public bool AddEmploye(Employee p)
        {
            db.Employee.Add(p);//sağlandıysa bu işlemler gerçekleştirsin.
           return db.SaveChanges() > 0;
        }
        public bool DeleteEmploye(int id)
        {
            var person = db.Employee.Find(id);
            db.Employee.Remove(person);
           return db.SaveChanges() > 0;
        }

        public bool BringEmployee ( int id )
        {
            var prs = db.Employee.Find(id);
            return prs != null;
        }
        public bool UpdateEmployee(Employee p)
        {
            var prs = db.Employee.Find(p.Id);
            prs.Employees = p.Employees;
           return db.SaveChanges() > 0;
        }
    }
}
