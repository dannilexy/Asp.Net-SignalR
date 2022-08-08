using Microsoft.AspNetCore.SignalR;

namespace SignalR.Hubs
{
    public class NotificationHub : Hub
    {
        public static int notificaionCounter = 0;
        public static List<string> messages = new List<string>();
        public async Task SendMessage(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                notificaionCounter++;
                messages.Add(message);
                await LoadMessages();
            }
        }

        public async Task LoadMessages()
        {
            await Clients.All.SendAsync("LoadNotification", messages, notificaionCounter);
        }
    }
}
