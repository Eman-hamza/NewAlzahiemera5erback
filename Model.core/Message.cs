using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.core
{
    public class Message
    {

        public int Id { get; set; }
        public string Content { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        public DateTime Date{ get; set; }


        [ForeignKey("Sender")]
        public string SenderId { get; set; }

        [ForeignKey("Reciever")]
        public string RecieverId { get; set; }
        public virtual ApplicationUser Reciever { get; set; }
        public virtual ApplicationUser Sender { get; set; }


        ////List<ApplicationUser> SenderId { get; set; }
        ////List<ApplicationUser> RecieverId { get; set; }

    }
}
