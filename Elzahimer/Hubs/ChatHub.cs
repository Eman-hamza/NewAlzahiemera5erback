using Elzahimer.DTO;
using Microsoft.AspNetCore.SignalR;

namespace Elzahimer.Hubs
{
    public class ChatHub:Hub
    {
        public async Task NewMassameAdded(ChatDTO chatdto)
        {
            Clients.All.SendAsync("ReceiveOneNotify", chatdto);
        }
    }
}
