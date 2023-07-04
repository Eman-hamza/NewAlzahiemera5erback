using Elzahimer.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.core;
using Model.core.Interface;
using System.IO;

namespace Elzahimer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelperController : ControllerBase
    {
        private readonly IUnitOfWorkRepository unitOfWorkRepository;
        public HelperController(IUnitOfWorkRepository unitOfWorkRepository)
        {
            this.unitOfWorkRepository = unitOfWorkRepository;
        }
/*
        //[HttpPost("AddHelper")]
        //public async Task<IActionResult> AddHelper(HelperDTO helperDTO) {
        //    Helper helper=new Helper();
        //    ApplicationUser applicationUser = new ApplicationUser();
        //    if (ModelState.IsValid)
        //    {
        //        helper.Id = helperDTO.Id;
        //        helper.PricePerHour= helperDTO.PricePerHour;
        //        await unitOfWorkRepository.Helper.AddAsync(helper);

        //        return new StatusCodeResult(StatusCodes.Status201Created); 
        //    }

        //    return BadRequest(ModelState);
        //}

        //[HttpGet("GetAllHelper")]
        //public async Task<IActionResult> GetAllHelper()
        //{
        //    List<Helper> helpers =(List<Helper>) await unitOfWorkRepository.Helper.GetAllAsync();
        //    return Ok(helpers);
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetHelperById(string id)
        //{
        //    return Ok(await unitOfWorkRepository.Helper.FindAsync(e => e.Id==id, new[]{"User"}));
        //}



        //[HttpDelete("DeleteHelper")]
        //public async Task<IActionResult> DeleteHelper(string id)
        //{
        //    var helper = (await unitOfWorkRepository.Helper.FindAsync(e => e.Id == id));
        //    helper.IsDeleted = true;
        //    unitOfWorkRepository.Helper.Delete(helper);
        //    return Ok("Deleted");
        //}*/

    }
}
