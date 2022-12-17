using MANotification.Models;

namespace MANotification.Hubs
{
    public interface IUserHub
    {
        Task createUser(User user);
    }
}