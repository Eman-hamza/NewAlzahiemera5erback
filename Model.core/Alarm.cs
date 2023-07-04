using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.core
{
   public class Alarm
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateTime { get; set; }  
        public string MedicenName { get; set; }
        public string dose { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}
