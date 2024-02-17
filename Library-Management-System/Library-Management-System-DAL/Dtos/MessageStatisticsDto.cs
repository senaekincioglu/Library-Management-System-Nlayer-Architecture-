using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System_DAL.Dtos
{
    public class MessageStatisticsDto
    {
        public int NumberOfIncomingMessages { get; set; }
        public int NumberOfOutgoingMessages { get; set; }
    }
}
