using stock_app_api.Models;
using stock_app_api.ViewModels;
using stock_app_api.ViewModels.DTOs;

namespace stock_app_api.Services.IServices
{
    public interface IUserService
    {
        Task<UserDTO> Register(RegisterVM registerVM);
        Task<UserDTO> Login(LoginViewModel loginViewModel);
        
    }
}
