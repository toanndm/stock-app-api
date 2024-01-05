using stock_app_api.Models;
using stock_app_api.ViewModels;

namespace stock_app_api.Services.IServices
{
    public interface IUserService
    {
        Task<User?> Register(RegisterVM registerVM);
    }
}
