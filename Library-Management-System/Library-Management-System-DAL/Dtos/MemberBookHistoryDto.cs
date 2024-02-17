using Library_Management_System_DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System_DAL.Dtos
{
    public class MemberBookHistoryDto
    {
        public string MemberName { get; set; }
        public List<Movement> BookHistory { get; set; }
    }
}
