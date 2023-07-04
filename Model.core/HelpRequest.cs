using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.core
{
   public class HelpRequest
    {
        public int Id { set; get; }
        public string Discription { set; get; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        public DateTime Date { set; get; }
        [ForeignKey("User")]
        public string? userId { set; get; }
        public virtual ApplicationUser User { set; get; }

        public List<HelperProposal> helperProposals { set; get; }
    }
}
