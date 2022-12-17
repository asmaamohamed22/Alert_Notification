using MANotification.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MANotification.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly MAContext _context;
        public UserRepository(MAContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<int> AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            int save = await _context.SaveChangesAsync();
            return save;
        }
    }
}
