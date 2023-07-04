using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.core.Interface
{
    public interface IMessageRepository
    {
        List<Message> GetAll(string sender, string reciver); 
    }
}
