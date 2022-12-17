using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MANotification.Models
{
    public class UsersNotifications
    {
        [Key]
        public int Id { get; set; }
        public DateTime? SeenTime { get; set; }

        [ForeignKey("Notification")]
        public int NotificationId { get; set; }
        public Notification? Notification { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
