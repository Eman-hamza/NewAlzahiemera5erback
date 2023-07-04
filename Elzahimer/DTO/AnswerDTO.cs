using System.ComponentModel.DataAnnotations.Schema;

namespace Elzahimer.DTO
{
    public class AnswerDTO
    {
        //public int id { get; set; }
        public string Ans { get; set; }
        public int Score { get; set; }
        
        public int QuestionID { get; set; }

        //public int TestId { get; set; }

    }
}
