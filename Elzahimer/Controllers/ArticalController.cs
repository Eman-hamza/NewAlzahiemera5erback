using Elzahimer.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.core;
using Model.core.Interface;
using System.Data;

namespace Elzahimer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticalController : ControllerBase
    {
        private readonly IUnitOfWorkRepository unitOfWorkRepository;
        public ArticalController(IUnitOfWorkRepository unitOfWorkRepository)
        {
            this.unitOfWorkRepository = unitOfWorkRepository;
        }

        [HttpPost("AddArtical")]
        public async Task<IActionResult> AddArtical(ArticalDTO articalDTO)
        {
            Artical artical = new Artical();
            if (ModelState.IsValid)
            {
                //using var dataStream = new MemoryStream();
              //  articalDTO.Image.CopyTo(dataStream);
                artical.paragraph = articalDTO.paragraph;
                artical.tiltle = articalDTO.tiltle;
                artical.Date = DateTime.Today;
                //artical.image = dataStream.ToArray();
                await unitOfWorkRepository.Artical.AddAsync(artical);
                return new StatusCodeResult(StatusCodes.Status201Created);
            }       
            return BadRequest(ModelState);
        }

        [HttpGet("GetAllArticals")]
        public async Task<IActionResult> GetAllArtical()
        {    
            return Ok(await unitOfWorkRepository.Artical.FindAllAsync(e=>e.IsDeleted==false));
        }

        [HttpPut("update")]
        public async Task<IActionResult> updateArtical(ArticalDTO articalDTO)
        {
            if (ModelState.IsValid)
            {
                Artical artical = await unitOfWorkRepository.Artical.FindAsync(a => a.Id == articalDTO.Id);
                //using var dataStream = new MemoryStream();
                //  articalDTO.Image.CopyTo(dataStream);
                artical.paragraph = articalDTO.paragraph;
                artical.tiltle = articalDTO.tiltle;
                //artical.image=dataStream.ToArray();
                unitOfWorkRepository.Artical.Update(artical);
                return Ok("updated");
            }
            return BadRequest(ModelState);

        }

        [HttpDelete("DeleteArtical")]
        public async Task<IActionResult> DeleteArtical(int id)
        {
            Artical artical=await unitOfWorkRepository.Artical.GetByIdAsync(id);
            artical.IsDeleted = true;
             unitOfWorkRepository.Artical.Delete(artical);
            return Ok("Deleted");
        }

        [HttpGet("GetByTitle/{id:int}")]
        public async Task<IActionResult> GetArticalById(int id)
        {
            return Ok(await unitOfWorkRepository.Artical.FindAsync(e => e.Id ==id));
        }


        [HttpGet("GetByTitle")]
        public IActionResult GetByTitle(string Title)
        {
           List<Artical> articals=unitOfWorkRepository.ArticalReposatory.GetByTitle(Title);
            return Ok(articals);
        }


        [HttpGet("GetByDate")]
        public IActionResult GetByDate(DateTime date)
        {
            List<Artical> articals = unitOfWorkRepository.ArticalReposatory.GetByDate(date);
            return Ok(articals);
        }

    }
}
