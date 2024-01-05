using stock_app_api.Models;
using stock_app_api.ViewModels;

namespace stock_app_api.Repositories.IRepository
{
    public interface IUserRepository
    {
        Task<User?> GetById(int  id);
        Task<User?> GetByUserName(string username);
        Task<User?> GetByEmail(string email);
        Task<User?> Create(RegisterVM registerVM);
    }
}
