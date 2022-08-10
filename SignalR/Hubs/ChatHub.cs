using Microsoft.AspNetCore.SignalR;

namespace SignalR.Hubs
{

    public class ChatHub : Hub
    {
        public async Task SendMessageToAll(string user, string message)
        {
            if (!string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(message))
            {
                await Clients.All.SendAsync("MessageReceived", user, message);

            }
        }

    }

}
