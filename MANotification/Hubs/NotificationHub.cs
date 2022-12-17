using MANotification.Models;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace MANotification.Hubs
{
    [HubName("notification")]
    public class NotificationHub : Hub<INotificationHub>
    {
        public async Task createNotification(Notification notification)
        {
            await Clients.All.createNotification(notification);
        }
    }
}
