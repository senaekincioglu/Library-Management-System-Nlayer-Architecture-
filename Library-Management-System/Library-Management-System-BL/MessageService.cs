using Library_Management_System_DAL.Dtos;
using Library_Management_System_DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Library_Management_System_BL
{
    public class MessageService
    {
        devrimme_senaEntities db = new devrimme_senaEntities();

        public List<Message> GetIncomingMessages(string userEmail)
        {
            return db.Message.Where(x => x.Buyer == userEmail).ToList();
        }

        public List<Message> GetOutgoingMessages(string memberMail)
        {
            return db.Message.Where(x => x.Sender == memberMail).ToList();
        }

        public bool SendMessage(Message t)
        {
            db.Message.Add(t);
           return db.SaveChanges() >0;
        }

        public MessageStatisticsDto GetMessageStatistics(string userEmail)
        {
            var statsDto = new MessageStatisticsDto();
            statsDto.NumberOfIncomingMessages = db.Message.Count(x => x.Buyer == userEmail);
            statsDto.NumberOfOutgoingMessages = db.Message.Count(x => x.Sender == userEmail);
            return statsDto;
        }


    }
}

