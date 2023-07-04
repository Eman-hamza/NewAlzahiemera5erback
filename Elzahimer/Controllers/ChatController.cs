using Elzahimer.DTO;
using Elzahimer.Hubs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Model.core;
using Reposatory.EF.Repositories;

namespace Elzahimer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly UnitOfWorkRepository unitOfWorkRepository;
       
        public ChatController(UnitOfWorkRepository unitOfWorkRepository, IHubContext<ChatHub> hubContext) { 
            this.unitOfWorkRepository = unitOfWorkRepository;
        }
        [HttpPost("SendMessage")]
        public async Task<IActionResult> SendMessage(ChatDTO msg)
        {
            Message message = new Message
            {
                Content = msg.msgText,
                RecieverId = msg.ReciverId,
                SenderId = msg.SenderId,
                Date = DateTime.Now,
            };

           await unitOfWorkRepository.Message.AddAsync(message);
            return Ok("Add");
        }

        [HttpGet("GetMessage")]
        public  IActionResult GetMessage(string sender, string reciver)
        {
            List<Message> messages = unitOfWorkRepository.MessageRepository.GetAll(sender,reciver);
           
            return Ok(messages);
        }

        [HttpGet("GetUserName")]
        public IActionResult GetUserName(string userId)
        {
            ApplicationUser username = unitOfWorkRepository.ApplicationUser.GetByIDString(userId);
            return Ok(username);

        }
    }
}
