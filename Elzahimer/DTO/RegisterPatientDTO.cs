using Model.core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Elzahimer.DTO
{
    public class RegisterPatientDTO
    {

       public DateTime bithDate { get; set; }
        public Relative relative { get; set; }
        public diseaselevel diseaselevel { get; set; }

        public string deseasDiscription { get; set; }
        public string username { get; set; }
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
