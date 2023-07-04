using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Model.core
{
   public class Helper
    {
        [Key]
        [ForeignKey("User")]
        public string Id { get; set; }
        public double? PricePerHour { get; set; }
        public bool IsHelper { get; set; }
        public bool IsPatient { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
        public ApplicationUser User { get; set; }
    }
}
