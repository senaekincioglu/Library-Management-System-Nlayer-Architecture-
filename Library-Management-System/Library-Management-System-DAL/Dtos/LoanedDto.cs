using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Management_System_DAL.Dtos;

namespace Library_Management_System_DAL.Dtos
{
    public class LoanedDto
    {
        public int MemberId { get; set; }
        public int BookId { get; set; }
        public int EmployeeId { get; set; }
    }
}
