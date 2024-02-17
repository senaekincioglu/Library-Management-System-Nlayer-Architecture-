using Library_Management_System_DAL.Dtos;
using Library_Management_System_DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library_Management_System_BL
{
    public class BookService
    {
        devrimme_senaEntities db = new devrimme_senaEntities();

        public IEnumerable<Book> GetBook(string p)
        {
            var kitaplar = from k in db.Book select k;
            if (!string.IsNullOrEmpty(p))
            {
                kitaplar = kitaplar.Where(m => m.Name.Contains(p));
            }
            return kitaplar.ToList();
        }

        public bool AddBook(Book p)
        {
            var ktg = db.Category.Where(k => k.Id == p.Category.Id).FirstOrDefault();//ilişkili tablolarda geçerli
            var yzr = db.Author.Where(y => y.Id == p.Author.Id).FirstOrDefault();
            p.Category = ktg;
            p.Author = yzr;
            db.Book.Add(p);
           return db.SaveChanges() > 0;
        }

        public bool DeleteBook(int id)
        {
            var kitap = db.Book.Find(id);
            db.Book.Remove(kitap);
            return db.SaveChanges() > 0;
        }

        public bool UpdateBook(Book p)
        {
            var kitap = db.Book.Find(p.Id);
            kitap.Name = p.Name;
            kitap.PrintYear = p.PrintYear;
            kitap.Page = p.Page;
            kitap.Publisher = p.Publisher;
            kitap.Status = true;
            var ktg = db.Category.Where(k => k.Id == p.Category.Id).FirstOrDefault();
            var yzr = db.Author.Where(y => y.Id == p.Author.Id).FirstOrDefault();
            kitap.Category_Id = ktg.Id;
            kitap.Author_Id = yzr.Id;
            kitap.BookPicture = p.BookPicture;
         return db.SaveChanges() > 0;
        }

        public Book BringBook(int id)
        {
            var ktp = db.Book.Find(id);
            return ktp;
        }

        public List<ListItemDto> GetCategories()

        {
            List<ListItemDto> deger1 = (from i in db.Category.ToList() //ilişkili tablolarda geçerli
                                           select new ListItemDto
                                           {
                                               Text = i.Name,
                                               Value = i.Id.ToString()
                                           }).ToList();

            return deger1;
        }

        public List<ListItemDto> GetAuthors()
        {
            List<ListItemDto> deger2 = (from i in db.Author.ToList()
                                           select new ListItemDto
                                           {
                                               Text = i.Name + ' ' + i.Surname,
                                               Value = i.Id.ToString()
                                           }).ToList();

            return deger2;
        }



    }
}
