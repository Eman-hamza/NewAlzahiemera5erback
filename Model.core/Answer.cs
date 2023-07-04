using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.core
{
    public class Answer
    {
        public int id {  get; set; }    
        public string Ans {  get; set; }
        public int Score { get; set; }
        [ForeignKey("Question")]
        public int QuestionID { get; set; }
        public Question Question { get; set; }
    }
}
