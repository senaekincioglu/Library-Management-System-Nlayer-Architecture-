using Library_Management_System_DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System_BL
{
    public class RegisterService
    {
        devrimme_senaEntities db = new devrimme_senaEntities();

        public bool MemberS(Member p)
        {
            db.Member.Add(p);
            return db.SaveChanges() > 0;
        }
    }
}
