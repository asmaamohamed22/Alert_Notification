using MANotification.Models;

namespace MANotification.Services
{
    public interface IUserRepository
    {
        Task<int> AddUser(User user);
        Task<IEnumerable<User>> GetUsers();
    }
}