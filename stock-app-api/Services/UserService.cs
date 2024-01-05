using stock_app_api.Models;
using stock_app_api.Repositories.IRepository;
using stock_app_api.Services.IServices;
using stock_app_api.ViewModels;

namespace stock_app_api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> Register(RegisterVM registerVM)
        {

            User? existingUserByUsername = await _userRepository.GetByUserName(registerVM.Username ?? "");
            if (existingUserByUsername != null)
            {
                throw new ArgumentException("Username already exists");
            }
            User? existingUserByEmail = await _userRepository.GetByEmail(registerVM.Username ?? "");
            if (existingUserByEmail != null)
            {
                throw new ArgumentException("Username already exists");
            }
            if (registerVM.Password != registerVM.PasswordConfirmation)
            {
                throw new ArgumentException("Password confirmation does not match the entered password.");
            }
            return await _userRepository.Create(registerVM);
        }
    }
}
