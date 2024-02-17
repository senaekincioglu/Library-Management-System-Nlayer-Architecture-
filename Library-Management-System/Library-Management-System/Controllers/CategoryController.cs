using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library_Management_System_DAL.Entity;
using Library_Management_System_BL;
using Microsoft.Ajax.Utilities; //oluşturduğun projeyi model ile birlikte yani sql de oluşturduğun tabloları proje ile birleştirmek için yazılır. ve her controller de yaz.
using Library_Management_System_DAL;
//MODELİN İÇERİSİNDE BULUNAN DEĞERLERE ULAŞMAKTIR
namespace Library_Management_System.Controllers
{
    public class CategoryController : Controller
    {
        CategoryService service = new CategoryService();
        // GET: Category
        public ActionResult Index()
        {

            var degerler = service.GetCategories();
            return View(degerler);
        }
        [HttpGet]//refresh 
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]//
        public ActionResult AddCategory(Category p ) //parametre tanımlanmasının sebebi kategori tablosundan alsın p ye atsın.
        {
            service.AddCategory(p);
            return RedirectToAction("Index");//ne yazdıysan sadece onu gösterir.
        }
        public ActionResult DeleteCategory(int id) //parametre id olacak çünkü id ye göre silme işlemi gerçekleştirecek.
        {
            service.DeleteCategory(id);
            return RedirectToAction("Index");//BAŞKA SAYFAYA YÖNLENDİRİR.
        }
        public ActionResult BringCategory(int id) //id ye göre parametre getirecek.
        {
            var ktg = service.BringCategory(id);
            return View("BringCategory", ktg);
        }
        public ActionResult UpdateCategory (Category p )
        {
           service.UpdateCategory(p);
            return RedirectToAction("Index");
        }

    }
}