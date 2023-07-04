using Model.core;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Elzahimer.DTO
{
    public class RegisterHelperDTO
    {
       
        public double pricePerHour { get; set; }
        public string username { get; set; }
        //public string FourthName { get; set; }
        public Gender gender { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public IFormFile image { get; set; }
        public string phoneNumber { get; set; }
        public string nationalId { get; set; }
        public bool isHelper { get; set; }
        public bool isPatient { get; set; }
        public string email { get; set; }
        public string password { get; set; }



    }
}
