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
using Library_Management_System_DAL.Dtos;

namespace Library_Management_System_BL
{
    public class MemberService
    {
        devrimme_senaEntities db = new devrimme_senaEntities();
        public IEnumerable<Member> GetMember(int sayfa = 1)
        {
            var degerler = db.Member.ToList().ToPagedList(sayfa, 3);
            return degerler;

        }

        public bool AddMember (Member p)
        {
            db.Member.Add(p);//sağlandıysa bu işlemler gerçekleştirsin.
           return  db.SaveChanges() >0 ;
        }

        public bool DeleteMember (int id)
        {
            var uye = db.Member.Find(id);
            db.Member.Remove(uye);
            return  db.SaveChanges() > 0;
        }

        public bool BringMember (int id)
        {
            var uye = db.Member.Find(id);
            return uye !=null;
        }
        public bool UpdateMember(Member p)
        {
            var uye = db.Member.Find(p.Id);
            uye.Name = p.Name;
            uye.Surname = p.Surname;
            uye.Mail = p.Mail;
            uye.UserName = p.UserName;
            uye.Password = p.Password;
            uye.School = p.School;
            uye.Telephone = p.Telephone;
            uye.Photograph = p.Photograph;
           return db.SaveChanges() > 0;

        }

        public MemberBookHistoryDto GetMemberBookHistory(int memberId)
        {
            var bookHistory = db.Movement.Where(x => x.Member_Id == memberId).ToList();
            var memberName = db.Member.Where(y => y.Id == memberId).Select(z => z.Name + " " + z.Surname).FirstOrDefault();

            var dto = new MemberBookHistoryDto
            {
                MemberName = memberName,
                BookHistory = bookHistory
            };

            return dto;
        }
    }
}
