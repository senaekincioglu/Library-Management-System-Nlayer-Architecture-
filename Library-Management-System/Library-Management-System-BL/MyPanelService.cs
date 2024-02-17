
using Library_Management_System_DAL.Dtos;
using Library_Management_System_DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace Library_Management_System_DAL
{
    public class MyPanelService
    {
        private devrimme_senaEntities db = new devrimme_senaEntities();
        public MyPanelDto GetPanelData(string userEmail)
        {
            var dto = new MyPanelDto();

            var member = db.Member.FirstOrDefault(z => z.Mail == userEmail);
            if (member != null)
            {
                dto.Name = member.Name;
                dto.Surname = member.Surname;
                dto.Photograph = member.Photograph;
                dto.UserName = member.UserName;
                dto.School = member.School;
                dto.Telephone = member.Telephone;
                dto.Mail = member.Mail;
                dto.MemberId = member.Id;

                dto.MovementCount = db.Movement.Count(x => x.Member_Id == member.Id);
                dto.MessageCount = db.Message.Count(x => x.Buyer == userEmail);
                dto.AnnouncementCount = db.Announcements.Count();
            }

            dto.Announcements = db.Announcements.ToList();

            return dto;
        }

        public Member GetMember(string userMail)
        {
            return db.Member.Where(x => x.Mail == userMail).FirstOrDefault();
        }

        public void UpdateMemberInfo(Member p)
        {
            var kullanici = (string)HttpContext.Current.Session["Mail"];
            var uye = db.Member.FirstOrDefault(x => x.Mail == kullanici);
            if (uye != null)
            {
                uye.Password = p.Password;
                uye.Name = p.Name;
                uye.Photograph = p.Photograph;
                uye.School = p.School;
                uye.UserName = p.UserName;
                db.SaveChanges();
            }
        }

        public List<Movement> GetMemberBooks(string userEmail)
        {
            var id = db.Member.Where(x => x.Mail == userEmail.ToString()).Select(z => z.Id).FirstOrDefault();
            return db.Movement.Where(x => x.Member_Id == id).ToList();
        }
    }

}

