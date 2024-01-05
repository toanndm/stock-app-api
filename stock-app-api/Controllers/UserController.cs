﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using stock_app_api.Models;
using stock_app_api.Services.IServices;
using stock_app_api.ViewModels;

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
                User? user = await _userService.Register(registerVM);
                return Ok(user);
            } catch (ArgumentException ex) 
            {
                return BadRequest(new { Message = ex.Message});
            }
        }
    }
}