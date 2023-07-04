using Elzahimer.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.core;
using Model.core.Interface;

namespace Elzahimer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelperProposalController : ControllerBase
    {
        private readonly IUnitOfWorkRepository unitOfWorkRepository;

        public HelperProposalController(IUnitOfWorkRepository unitOfWorkRepository)
        {
            this.unitOfWorkRepository = unitOfWorkRepository;
        }
        [HttpPost("AddHelperProposel")]
        public async Task<IActionResult> AddHelperProposel(HelperProposalDTO helperProposalDTO)
        {
            HelperProposal helperProposal= new HelperProposal();
            ApplicationUser applicationUser = new ApplicationUser();
            Data Return = new Data();
            if (ModelState.IsValid)
            {
                Return.Message = "Success";
                Return.IsPass = true;

                helperProposal.Id = helperProposalDTO.Id;
                helperProposal.userId = helperProposalDTO.userId;
                helperProposal.Discription = helperProposalDTO.Discription;
                helperProposal.Date = helperProposalDTO.Date;
                helperProposal.Price = helperProposalDTO.Price;
                helperProposal.HelpRequestId = helperProposalDTO.HelpRequestId;


                unitOfWorkRepository.HelperProposal.Add(helperProposal);


                return Ok(Return);
            }
            else
            {
                Return.Message = "patient not add";
                return Ok(Return);
            }

            return new StatusCodeResult(StatusCodes.Status201Created);
        }
        [HttpGet("GetAllHelperProposel")]
        public async Task<IActionResult> GetAllHelperProposel()
        {
            return Ok(await unitOfWorkRepository.HelperProposal.FindAllAsync(e => e.IsDeleted == false));
        }
        [HttpGet("GetAllHelperProposel/{id}")]
        public async Task<IActionResult> GetHelperProposelById(int id)
        {
            return Ok(await unitOfWorkRepository.HelperProposal.FindAllAsync(e => e.Id == id));
        }
        [HttpDelete("DeleteHelperProposel")]
        public async Task<IActionResult> DeleteHelperProposel(int id)
        {
            HelperProposal proposal= await unitOfWorkRepository.HelperProposal.GetByIdAsync(id);
            proposal.IsDeleted = true;
            unitOfWorkRepository.HelperProposal.Delete(proposal);
            return Ok("Deleted");
        }

    }
}
