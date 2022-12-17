using MANotification.Hubs;
using MANotification.Models;
using MANotification.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace MANotification.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationRepository _repo;
        private IHubContext<NotificationHub, INotificationHub> _notificationHub;
        public NotificationsController(INotificationRepository repo, IHubContext<NotificationHub, INotificationHub> _notificationHub)
        {
            this._repo = repo;
            this._notificationHub = _notificationHub;
        }


        // GET: api/Notifications
        [HttpGet]
        [Route("GetNotifications")]
        public async Task<IEnumerable<Notification>> GetNotifications()
        {
            return await _repo.GetNotifications();
        }

        // POST: api/Notifications
        [HttpPost]
        [Route("AddNoitification")]
        public async Task<IActionResult> AddNoitification(Notification notification)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                await _repo.AddNotification(notification);
                await _notificationHub.Clients.All.createNotification(notification);

                return Ok("Notification Added Successfully");
            }
        }

        // PUT: api/Notifications
        [HttpPut]
        [Route("AcknowledgeRead")]
        public async Task<IActionResult> AcknowledgeRead(int userId, int notificationId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                await _repo.AcknowledgeRead(userId, notificationId);
                return Ok("Notification Acknowledged By User Succesfully");
            }
        }
    }
}
