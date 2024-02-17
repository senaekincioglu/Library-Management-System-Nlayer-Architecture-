using Library_Management_System_DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System_BL
{
    public class AdminLoginService
    {
        devrimme_senaEntities db = new devrimme_senaEntities();

        public Admin Login(string userName, string password)
        {
            var informations = db.Admin.FirstOrDefault(x => x.UserName == userName && x.Password == password);

            return informations;
        }
    }
}
