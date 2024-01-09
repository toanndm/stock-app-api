using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using stock_app_api.Models;
using stock_app_api.Repositories.IRepository;
using stock_app_api.ViewModels;
using System.Security.Claims;

namespace stock_app_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchListController : ControllerBase
    {
        private readonly IWatchListRepository _watchListRepository;
        public WatchListController(IWatchListRepository watchListRepository)
        {
            _watchListRepository = watchListRepository;
        }
        [HttpGet("get")]
        [Authorize()]
        public async Task<IActionResult> GetWatchList(int page, int limit)
        {
            try
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (string.IsNullOrEmpty(userId))
                {
                    return BadRequest();
                }

                if (!int.TryParse(userId, out int userIdInt))
                {
                    return BadRequest();
                }

                IEnumerable<WatchList> watchLists = await _watchListRepository.GetWatchListByUserId(
                    userIdInt, 
                    page, 
                    limit);
                var watchListsResponse = watchLists.Select(wl => new
                {
                    wl.WatchId,
                    wl.UserId,
                    wl.StockId
                });
                return Ok(watchListsResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
        [HttpPost("add")]
        [Authorize]
        public async Task<IActionResult> AddWatchList(WatchListViewModel watchListViewModel)
        {
            try
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (string.IsNullOrEmpty(userId))
                {
                    return BadRequest();
                }

                if (!int.TryParse(userId, out int userIdInt))
                {
                    return BadRequest();
                }
                WatchList watchList = new WatchList
                {
                    StockId = watchListViewModel.StockId,
                    UserId = userIdInt
                };
                var response = await _watchListRepository.AddWatchList(watchList);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
