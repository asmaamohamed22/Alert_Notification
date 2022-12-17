using MANotification.Models;
using Microsoft.EntityFrameworkCore;

namespace MANotification.Services
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly MAContext _context;
        public NotificationRepository(MAContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get All Notifications
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Notification>> GetNotifications()
        {
            return await _context.Notifications.ToListAsync();
        }

        /// <summary>
        ///  Add Notification And Send it To All Users
        /// </summary>
        /// <param name="notification"></param>
        /// <returns></returns>
        public async Task<int> AddNotification(Notification notification)
        {
            await _context.Notifications.AddAsync(notification);
            int save = await _context.SaveChangesAsync();
            var users = _context.Users.ToList();
            if (users.Count > 0)
            {
                foreach (var user in users)
                {
                    var UserNotification = new UsersNotifications()
                    {
                        UserId = user.Id,
                        NotificationId = notification.Id,
                    };
                    await _context.UsersNotifications.AddAsync(UserNotification);
                    await _context.SaveChangesAsync();
                }
            }
            return save;
        }

        /// <summary>
        /// User Read Notification that has been sent
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="notificationId"></param>
        /// <returns></returns>
        public async Task<int> AcknowledgeRead(int userId, int notificationId)
        {
            var UserNotification = _context.UsersNotifications
                .FirstOrDefault(u => u.UserId == userId && u.NotificationId == notificationId);
            if (UserNotification!= null)
            {
                UserNotification.SeenTime = DateTime.Now;
            }
            var save = await _context.SaveChangesAsync();
            return save;
        }

    }
}
