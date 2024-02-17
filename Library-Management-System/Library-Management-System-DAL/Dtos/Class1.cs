using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using Library_Management_System_DAL.Entity;

namespace Library_Management_System_DAL.Dtos
{
    public class IndexDto
    {
        public IEnumerable<Book> Deger1 { get; set; }
        public IEnumerable<About> Deger2 { get; set; }

    }
}