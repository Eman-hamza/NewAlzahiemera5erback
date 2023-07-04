using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.core
{
    public class HelperProposal
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string Discription { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        public DateTime  Date{get; set;}
        [ForeignKey("User")]
        public string? userId { get; set; }

        [ForeignKey("HelpRequest")]
        public int HelpRequestId { get; set; }

        public virtual HelpRequest HelpRequest{ get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}