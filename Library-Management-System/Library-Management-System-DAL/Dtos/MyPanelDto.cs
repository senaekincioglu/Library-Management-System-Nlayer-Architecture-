using Library_Management_System_DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System_DAL.Dtos
{
    public class MyPanelDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Photograph { get; set; }
        public string UserName { get; set; }
        public string School { get; set; }
        public string Telephone { get; set; }
        public string Mail { get; set; }
        public int MemberId { get; set; }
        public int MovementCount { get; set; }
        public int MessageCount { get; set; }
        public int AnnouncementCount { get; set; }
        public List<Announcements> Announcements { get; set; }
    }
}
