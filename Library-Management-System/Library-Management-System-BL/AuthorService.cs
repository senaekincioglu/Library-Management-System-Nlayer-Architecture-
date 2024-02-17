using Library_Management_System_DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System_BL
{
    public class AuthorService
    {
        devrimme_senaEntities db = new devrimme_senaEntities();

        public IEnumerable<Author> GetAuthors()
        {
            var degerler = db.Author.ToList();
            return degerler;
        }

        public bool DeleteAuthor(int id)
        {
            var yazar = db.Author.Find(id);
            db.Author.Remove(yazar);
            return db.SaveChanges() > 0;
        }

        public bool UpdateAuthor(Author p)
        {
            var yzr = db.Author.Find(p.Id);
            yzr.Name = p.Name;
            yzr.Surname = p.Surname;
            yzr.Detail = p.Detail;
           return  db.SaveChanges() > 0;
        }

        public bool BringAuthor (int id)
        {
            var yzr = db.Author.Find(id);
            return yzr != null;
        }
        public bool AddAuthor (Author p)
        {
            db.Author.Add(p);//if geçerli değilse zaten burdaki işlemleri döndürür.
            return db.SaveChanges() > 0;
        }

          public string AuthorBooks ( int id)
        {
            var author = db.Book.Where(x => x.Author_Id == id).ToList();  //o kitabın ıd si id ye eşitse sadece onu getir yani sadece seçtiğin yazarın ıd sine göre alıyor.
            var authorname = db.Author.Where(y => y.Id == id).Select(z => z.Name + " " + z.Surname).FirstOrDefault(); //yazarın tablosundan yazarın id sine göre adını ve soyadını getir ama ilk çıkan değer. ID demesinin sebebi sadece o yazara ait getir demek. üyede de aynısı geçerli sadece o üyeye ait demek. İd sindeki ismi getir demek.
            return authorname;
        }
    }
}
