using Library_Management_System_DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System_BL
{
    public class AdminRoleProviderService
    {
        public bool GetRolesForUser(string username)
        {
            devrimme_senaEntities db = new devrimme_senaEntities();
            var deger = db.Admin.FirstOrDefault(x => x.UserName == username);
            return deger != null;
        }

    }
}
