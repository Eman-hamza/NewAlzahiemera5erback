using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Model.core
{
    public class Test
    {
        public int id { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        public string title { get; set; }
        public int minDegree { get; set; }
        public int middleDegree { get; set; }
        public int MaxDegree { get; set; }
        [JsonIgnore]
        public List<Question>? questions { get; set; } = new List<Question>();
   
    

       
      
    }
}
