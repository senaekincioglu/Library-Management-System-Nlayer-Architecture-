using Library_Management_System_DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System_BL
{
    public class AnnouncementService
    {
        devrimme_senaEntities db = new devrimme_senaEntities();

        public IEnumerable<Announcements> GetAnnouncements()
        {
            var degerler = db.Announcements.ToList();
            return degerler;
        }

        public bool AddAnnouncement(Announcements entity)
        {

            db.Announcements.Add(entity);
            return db.SaveChanges() > 0;
        }

        public bool DeleteAnnouncement(int id)
        {
            var announcement = db.Announcements.Find(id);
            db.Announcements.Remove(announcement);
            return db.SaveChanges() > 0;
        }

        public Announcements AnnouncementDetail(Announcements p)
        {
            var announcement = db.Announcements.Find(p.Id);

            return announcement;
        }

        public bool UpdateAnnouncement(Announcements t)
        {
            var announcement = db.Announcements.Find(t.Id);
            announcement.CategoryText = t.CategoryText;
            announcement.Contents = t.Contents;
            announcement.Date = t.Date;
            return db.SaveChanges() > 0;
        }
    }
}
