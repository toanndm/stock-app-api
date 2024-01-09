using stock_app_api.Models;
using stock_app_api.ViewModels;
using stock_app_api.ViewModels.DTOs;

namespace stock_app_api.Repositories.IRepository
{
    public interface IUserRepository
    {
        Task<User?> GetById(int  id);
        Task<User?> GetByUserName(string username);
        Task<User?> GetByEmail(string email);
        Task<UserDTO> Create(RegisterVM registerVM);
        Task<UserDTO> Login(LoginViewModel loginViewModel);
    }
}
