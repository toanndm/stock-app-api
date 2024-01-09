using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using stock_app_api.Models;
using stock_app_api.Services.IServices;
using stock_app_api.ViewModels;
using stock_app_api.ViewModels.DTOs;

namespace stock_app_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            try
            {
                UserDTO? user = await _userService.Register(registerVM);
                return Ok(user);
            } catch (ArgumentException ex) 
            {
                return BadRequest(new { Message = ex.Message});
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            try
            {
                UserDTO user = await _userService.Login(loginViewModel);
                return Ok(user);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
