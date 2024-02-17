using Library_Management_System_DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System_BL
{
    public class ProcessService
    {
        devrimme_senaEntities db = new devrimme_senaEntities();
         public IEnumerable<Movement> GetProcess()
        {
            var deger = db.Movement.Where(x => x.TransactionStatus == true).ToList();
            return deger;
        }
    }
}
