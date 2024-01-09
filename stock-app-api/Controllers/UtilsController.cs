using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using stock_app_api.Services;
using stock_app_api.Services.IServices;
using System.Security.Claims;

namespace stock_app_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly INotificationService _notificationService;
        public UtilsController(ITransactionService transactionService, INotificationService notificationService)
        {
            _transactionService = transactionService;
            _notificationService = notificationService; 

        }
        [HttpGet("transactions")]
        public async Task<IActionResult> GetTransactions(int page, int limit)
        {
            int userId = GetUserId();
            if (userId == 0)
            {
                return BadRequest();
            }
            var transactions = await _transactionService.GetTransactions(userId, page, limit);
            return Ok(new { transactions, userId });
        }
        [HttpGet("notifications")]
        public async Task<IActionResult> GetNotification(int page, int limit)
        {
            int userId = GetUserId();
            if (userId == 0)
            {
                return BadRequest();
            }
            var notifications = await _notificationService.GetNotifications(userId, page, limit);
            return Ok(new { notifications, userId });
        }
        private int GetUserId()
        {
            var id = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(id))
            {
                return 0;
            }

            if (!int.TryParse(id, out int userId))
            {
                return 0;
            }
            return userId;
        }
    }
}
