using MANotification.Models;

namespace MANotification.Hubs
{
    public interface INotificationHub
    {
        Task createNotification(Notification notification);
    }
}