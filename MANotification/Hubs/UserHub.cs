using MANotification.Models;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace MANotification.Hubs
{
    [HubName("user")]
    public class UserHub : Hub<IUserHub>
    {
        public async Task createUser(User user)
        {
            await Clients.All.createUser(user);
        }
    }
}
