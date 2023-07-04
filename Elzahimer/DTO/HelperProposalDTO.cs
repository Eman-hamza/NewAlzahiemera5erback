using System.ComponentModel;

namespace Elzahimer.DTO
{
    public class HelperProposalDTO
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string Discription { get; set; }
        public DateTime Date { get; set; }
        public string? userId { get; set; }
        public int HelpRequestId { get; set; }


    }
}
