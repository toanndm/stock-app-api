using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using stock_app_api.Models;
using stock_app_api.Services.IServices;
using System.Net.WebSockets;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace stock_app_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private readonly IQuoteService _quoteService;
        public QuoteController(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        [HttpGet("ws")]
        public async Task GetRealTimeQuote(
            int page = 1,
            int limit = 10,
            string sector = "",
            string industry = "")
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                while (webSocket.State == System.Net.WebSockets.WebSocketState.Open)
                {
                    List<RealTimeQuote>? quotes = await _quoteService.GetRealTimeQuote(page, limit, sector, industry);
                    string jsonString = JsonSerializer.Serialize(quotes);
                    var buffer = Encoding.UTF8.GetBytes(jsonString);
                    await webSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text,
                        true, CancellationToken.None);
                    await Task.Delay(2000);  
                }
            }
        }
    }
}
