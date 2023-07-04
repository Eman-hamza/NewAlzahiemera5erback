namespace Elzahimer.DTO
{
    public class DataReturnLogin
    {
        public bool? IsPass { get; set; }
        public dynamic? DataReturn { get; set; }
        public string? Message { get; set; }

        public string? token { get; set; }
    }
}
