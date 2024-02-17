using Library_Management_System.Models;
using Library_Management_System_DAL.Dtos;
using Library_Management_System_DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Management_System_DAL;

namespace Library_Management_System_BL
{
    public class StatisticService
    {
        devrimme_senaEntities db = new devrimme_senaEntities();
        public IndexDto2 GetStatistic()
        {
            var deger1 = db.Member.Count(); // Tüm üyeleri getir
            var deger2 = db.Book.Count(); // Tüm kitapları getir
            var deger3 = db.Book.Where(x => x.Status == false).Count(); // Durumu false olan kitapları getir
            var deger4 = db.Punishment.Sum(x=>x.Money); // Tüm cezaları getir

            var  dto = new IndexDto2
            {
                Deger1 = deger1,
                Deger2 = deger2,
                Deger3 = deger3,
                Deger4 = deger4.Value
            };

            return dto;
        }

        public LinqCardDto GetLinqCardData()
        {
            var data = new LinqCardDto
            {
                Deger1 = db.Book.Count(),
                Deger2 = db.Member.Count(),
                Deger3 = db.Punishment.Sum(x => x.Money).GetValueOrDefault(),
                Deger4 = db.Book.Count(x => x.Status == false),
                Deger5 = db.Category.Count(),
                Deger8 = db.MostBookAuthors().FirstOrDefault(),
                Deger9 = db.Book.GroupBy(x => x.Publisher).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault(),
                Deger11 = db.Contact.Count()
            };

            return data;
        }

    }
}
