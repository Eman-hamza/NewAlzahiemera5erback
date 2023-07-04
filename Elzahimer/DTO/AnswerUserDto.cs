namespace Elzahimer.DTO
{
    public class AnswerUserDto
    {
        public string? userId { get; set; }
        public int ExamId { get; set; }
        public List<QAns> QAns { get; set; }
        
    }
}
