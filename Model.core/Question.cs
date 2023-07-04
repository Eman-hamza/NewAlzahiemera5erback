using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.core
{
    public class Question
    {
        public int Id { get; set; }
        public string question { get; set; }      
        public bool IsDeleted { get; set; }
         //public string CorrectAns { get; set; }
        public List<Answer> Answers { get; set; } 

        [ForeignKey("Test")]
        public int TestId { get; set; } 
        public Test Test { get; set; }
    }
}
