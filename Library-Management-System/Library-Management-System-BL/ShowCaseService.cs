using Library_Management_System_DAL.Dtos;
using Library_Management_System_DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System_BL
{
    public class ShowCaseService
    {
        devrimme_senaEntities db = new devrimme_senaEntities();

        public IndexDto GetIndexDto()
        {
            IndexDto cs = new IndexDto();
            cs.Deger1 = db.Book.ToList();
            cs.Deger2 = db.About.ToList();
            return cs;
        }

        public bool AddContact(Contact c)
        {

            db.Contact.Add(c);
            return db.SaveChanges() > 0;
        }
    }
}
