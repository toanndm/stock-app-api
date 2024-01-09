using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using stock_app_api.Services.IServices;
using stock_app_api.ViewModels;
using System.Security.Claims;

namespace stock_app_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost("placeorder")]
        public async Task<IActionResult> PlaceOrder(OrderViewModel orderViewModel)
        {
            var id = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            if (!int.TryParse(id, out int userId))
            {
                return BadRequest();
            }
            var order = await _orderService.PlaceOrder(orderViewModel, userId);
            return Ok(new { order, userId });
        }
        [HttpGet("")]
        public async Task<IActionResult> GetOrders(int page, int limit)
        {
            var id = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            if (!int.TryParse(id, out int userId))
            {
                return BadRequest();
            }
            var orders = await _orderService.GetOrders(userId, page, limit);
            return Ok(new { orders, userId });
        }
    }
}
