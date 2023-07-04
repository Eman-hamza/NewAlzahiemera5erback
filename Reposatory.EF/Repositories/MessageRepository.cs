using Model.core.Interface;
using Model.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Reposatory.EF.Repositories
{
    internal class MessageRepository : BaseRepository<Message>, IMessageRepository
    {
        ApplicationDBContext context;
        public MessageRepository(ApplicationDBContext context) : base(context)
        {
            this.context = context;
        }

        public List<Message> GetAll(string sender,string reciver)
        { 
            List<Message> messages = context.Messages.Where(m => (m.SenderId == sender && m.RecieverId == reciver)
            || (m.SenderId == reciver && m.RecieverId == sender)
            ).Include(u => u.Sender).Include(u => u.Reciever).ToList();
           return messages;
        }
    }
}
