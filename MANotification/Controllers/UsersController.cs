
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MANotification.Models;
using MANotification.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNet.SignalR.Messaging;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Identity;
using MANotification.Hubs;
using Microsoft.AspNet.SignalR;

namespace MANotification.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private IHubContext<UserHub, IUserHub> _userHub;
        public UsersController(IUserRepository repo, IHubContext<UserHub, IUserHub> _userHub)
        {
            this._repo = repo;
            this._userHub = _userHub;
        }

        // GET: api/Users
        [HttpGet]
        [Route("GetUsers")]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _repo.GetUsers();
        }

        // POST: api/Users
        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                await _repo.AddUser(user);
                await _userHub.Clients.All.createUser(user);

                return Ok("User Added Successfully!");
            }
        }
    }
}
