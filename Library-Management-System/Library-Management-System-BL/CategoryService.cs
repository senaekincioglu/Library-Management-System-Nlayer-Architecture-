using Library_Management_System_DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System_BL
{
    public class CategoryService
    {
        devrimme_senaEntities db = new devrimme_senaEntities();

        public IEnumerable<Category> GetCategories()
        {
            var degerler = db.Category.Where(x => x.Status == true).OrderBy(x => x.Name).ToList();
            return degerler;
        }
        public bool AddCategory(Category p)
        {
            db.Category.Add(p);// kategori tablosuna eklesin kategoriye eklenen değerleri
           return db.SaveChanges() > 0;
        }
        public bool DeleteCategory(int id)
        {
            var category = db.Category.Find(id);//find bul demek.
            //db.Category.Remove(category); 
            category.Status = false;//sadece id ye göre gelen durumu false yapıcak. eğer kitap false ise silecek.yani kitap sile basınca silinmeyecek false düşecek. sql de kontrol et false a düşüyor.
           return db.SaveChanges() > 0;
        }

         public Category  BringCategory(int id)
        {
            var ktg = db.Category.Find(id);
            return ktg ;
        }

        public bool UpdateCategory(Category p)
        {
            var ktg = db.Category.Find(p.Id);
            ktg.Name = p.Name;
           return db.SaveChanges() > 0;
        }

    }
}
