using MANotification.Models;

namespace MANotification.Services
{
    public interface INotificationRepository
    {
        Task<int> AcknowledgeRead(int userId, int notificationId);
        Task<int> AddNotification(Notification notification);
        Task<IEnumerable<Notification>> GetNotifications();
    }
}