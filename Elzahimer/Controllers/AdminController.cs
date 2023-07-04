using Elzahimer.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.core;
using Model.core.Interface;

namespace Elzahimer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IUnitOfWorkRepository unitOfWorkRepository;
        public AdminController(IUnitOfWorkRepository unitOfWorkRepository)
        {
            this.unitOfWorkRepository = unitOfWorkRepository;
        }

        [HttpGet("GetPendingPatients")]
        public async Task<IActionResult> GetPendingPatients( Status status)
        {
          List<Patient> patients= (List<Patient>)await unitOfWorkRepository.Patient.FindAllAsync(e => e.User.Status == Status.Pending, new[] { "User" });
            return Ok(patients);
        }
        [HttpGet("GetPendingHelpers")]
        public async Task<IActionResult> GetPendingHelpers()
        {
            List<Helper> helpers = (List<Helper>)await unitOfWorkRepository.Helper.FindAllAsync(e => e.User.Status == Status.Pending, new[] { "User" });

            
            return Ok(helpers);
        }


        [HttpPut("ApproveHelper")]
        public IActionResult ApproveHelper( ApproveDTO approve )
        {
            Helper helper = (Helper)unitOfWorkRepository.helperRepository.FindHelper(approve.userId);
            if (helper != null && helper.User.Status!=null)
            {
                helper.User.Status = approve.status;
                unitOfWorkRepository.Helper.Update(helper);
                return Ok(helper);
            }
          return BadRequest();
            
        }



        [HttpPut("ApprovePatient")]
        public IActionResult ApprovePatient(ApproveDTO approve)
        {
            Patient patient = (Patient)unitOfWorkRepository.PatientRepository.FindPatient(approve.userId);
            /*            patient.User.Status = approve.status;*/
            if (patient != null && patient.User.Status != null)
            {
                patient.User.Status = approve.status;
                unitOfWorkRepository.Patient.Update(patient);
                return Ok(patient);
            }
            return BadRequest();
        }
    }
}
