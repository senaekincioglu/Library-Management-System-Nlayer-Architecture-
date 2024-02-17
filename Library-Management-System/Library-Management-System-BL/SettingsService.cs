using Library_Management_System_DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System_BL
{
    public class SettingsService
    {
        devrimme_senaEntities db = new devrimme_senaEntities();

        public IEnumerable<Admin> GetSettings()
        {
            var users = db.Admin.ToList();
            return users;

        }

        public IEnumerable<Admin> GetSettings2()
        {
            var users = db.Admin.ToList();
            return users;

        }

        public bool AddSetting(Admin t)
        {
            db.Admin.Add(t);
           return db.SaveChanges() > 0;
        }

        public bool DeleteSetting (int id)
        {
            var admin = db.Admin.Find(id);
            db.Admin.Remove(admin);
            return db.SaveChanges() > 0;
        }

        public bool UpdateAdmin(int id)
        {
            var admin = db.Admin.Find(id);
            return admin!=null;        
        }

        public bool UpdateAdmin(Admin p)
        {
            var admin = db.Admin.Find(p.Id);
            admin.UserName = p.UserName;
            admin.Password = p.Password;
            admin.Authority = p.Authority;
            return db.SaveChanges() > 0;
        }
    }
}
