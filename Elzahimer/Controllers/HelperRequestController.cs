using Elzahimer.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.core.Interface;
using Model.core;

namespace Elzahimer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelperRequestController : ControllerBase
    {
        private readonly IUnitOfWorkRepository unitOfWorkRepository;

        public HelperRequestController(IUnitOfWorkRepository unitOfWorkRepository)
        {
            this.unitOfWorkRepository = unitOfWorkRepository;
        }
        [HttpPost("AddHelperRequest")]
        public async Task<IActionResult> AddHelperRequest(HelperRequestDTO helperRequestDTO)
        {
            HelpRequest helpRequest= new HelpRequest();
            ApplicationUser applicationUser = new ApplicationUser();
            Data Return = new Data();
            if (ModelState.IsValid)
            {
                Return.Message = "Success";
                Return.IsPass = true;

                helpRequest.Id = helperRequestDTO.Id;
                helpRequest.userId = helperRequestDTO.userId;
                helpRequest.Discription = helperRequestDTO.Discription;
                helpRequest.Date = helperRequestDTO.Date;
 

                unitOfWorkRepository.HelpRequest.Add(helpRequest);


                return Ok(helpRequest);
            }
            else
            {
                Return.Message = "patient not add";
                return Ok(Return);
            }

            return new StatusCodeResult(StatusCodes.Status201Created);
        }
        [HttpGet("GetAllHelperRequest")]
        public async Task<IActionResult> GetAllHelperRequest()
        {
            return Ok(await unitOfWorkRepository.HelpRequest.FindAllAsync(e => e.IsDeleted == false));
        }
        [HttpGet("GetAllHelperRequest/{id}")]
        public async Task<IActionResult> GetRequestById(int id)
        {
            return Ok(await unitOfWorkRepository.HelpRequest.FindAllAsync(e=>e.Id==id));
        }
        [HttpDelete("DeleteHelperRequest")]
        public async Task<IActionResult> DeleteHelperRequest(int id)
        {
            HelpRequest request = await unitOfWorkRepository.HelpRequest.GetByIdAsync(id);
            request.IsDeleted = true;
            unitOfWorkRepository.HelpRequest.Delete(request);
            return Ok("Deleted");
        }
    }
}
