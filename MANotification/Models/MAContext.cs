
using Microsoft.EntityFrameworkCore;

namespace MANotification.Models
{
    public class MAContext : DbContext
    {
        public MAContext(DbContextOptions<MAContext> option) : base(option)
        {
            //......
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UsersNotifications> UsersNotifications { get; set; }
    }
}
