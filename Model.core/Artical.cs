using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.core
{
   public class Artical
    {
        public int Id { get; set; }
        public string tiltle { get; set; }

        public string paragraph { get; set; }
        //public byte[]? image { get; set; }
        public DateTime? Date { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }


    }
}
