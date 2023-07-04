using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.ComponentModel;

namespace Model.core
{

    public enum Relative
    {
       Son,
       Daughter,
       Sibling,
       Descendants,
       Friend,
       Other
    }

    public enum diseaselevel 
    {
        preclinical,
        mild_cognitive_impairment ,
        mild_dementia,
        moderate_dementia,
        severe_dementia
    }
    public class Patient
    {
        [Key]
        [ForeignKey("User")]
        public string Id { get; set; }
        public DateTime bithDate { get; set; }
        public Relative Relative { get; set; }
        public diseaselevel diseaselevel { get; set; }
   
        public string DeseasDiscription { get; set; }
        public bool IsHelper { get; set; }
        public bool IsPatient { get; set; }
        public ApplicationUser User { get; set; }

        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
