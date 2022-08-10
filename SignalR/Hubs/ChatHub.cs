using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalR.Data;

namespace SignalR.Hubs
{

    public class ChatHub : Hub
    {
        private readonly ApplicationDbContext _context;
        public ChatHub(ApplicationDbContext _context)
        {
            this._context = _context;
        }
        public async Task SendMessageToAll(string user, string message)
        {
            if (!string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(message))
            {
                await Clients.All.SendAsync("MessageReceived", user, message);

            }
        }

        [Authorize]
        public async Task SendMessageToReciever(string sender, string receiver, string message)
        {
            if (!string.IsNullOrEmpty(sender) && !string.IsNullOrEmpty(sender) && !string.IsNullOrEmpty(message))
            {
                var userId = _context.Users.FirstOrDefault(x => x.Email.ToLower() == receiver.ToLower()).Id;
                if (!string.IsNullOrEmpty(userId))
                {
                    await Clients.User(userId).SendAsync("MessageReceived", sender, message);

                }

            }
        }

    }

}
