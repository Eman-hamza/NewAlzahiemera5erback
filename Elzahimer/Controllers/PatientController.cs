using Elzahimer.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Model.core;
using Model.core.Interface;

namespace Elzahimer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IUnitOfWorkRepository unitOfWorkRepository;
        public PatientController(IUnitOfWorkRepository unitOfWorkRepository)
        {
            this.unitOfWorkRepository = unitOfWorkRepository;
        }
        //[HttpPost("AddPatient")]
        //public async Task<IActionResult> AddPatient(PatientDTO PatientDTO)
        //{
        //    Patient patient = new Patient();
        //    ApplicationUser applicationUser = new ApplicationUser();
        //    Data Return = new Data();
        //    if (ModelState.IsValid)
        //    {
        //            Return.Message = "Success";
        //            Return.IsPass = true;
        //            patient.Id = PatientDTO.Id;
        //            patient.Relative = PatientDTO.Relative;
        //            patient.bithDate = PatientDTO.bithDate;
        //            patient.DeseasDiscription = PatientDTO.DeseasDiscription;
        //            patient.diseaselevel = PatientDTO.diseaselevel;
                   
        //           unitOfWorkRepository.Patient.Add(patient);


        //        return Ok(patient);
        //    }
        //    else
        //    {
        //        Return.Message = "patient not add";
        //        return Ok(Return);
        //    }

        //        return new StatusCodeResult(StatusCodes.Status201Created);
        //}
        //[HttpGet("GetAllPaitent")]
        //public async Task<IActionResult> GetAllPatient()
        //{
        //    List<Patient> patients = (List<Patient>)await unitOfWorkRepository.Patient.FindAllAsync(e => e.IsDeleted == false);
        //    return Ok(patients);
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetPatientById(string id)
        //{
        //    return Ok(await unitOfWorkRepository.Patient.FindAsync(e => e.Id == id, new[] { "User" }));
        //}



        //[HttpDelete("DeletePatient")]
        //public async Task<IActionResult> DeletePatient(string id)
        //{
        //    var pat = (await unitOfWorkRepository.Patient.FindAsync(e => e.Id == id));
        //    pat.IsDeleted = true;
        //    unitOfWorkRepository.Patient.Delete(pat);
        //    return Ok(pat);
        //}
    }
}
