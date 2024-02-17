using Library_Management_System_DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Library_Management_System_BL
{
    public class LoginService
    {
        devrimme_senaEntities db = new devrimme_senaEntities();

        public bool Login(Member p)
        {
            var user = db.Member.FirstOrDefault(x => x.Mail == p.Mail && x.Password == p.Password);

            return (user != null);
        }
    }
}
