using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using stock_app_api.Configurations;
using stock_app_api.DataAccess;
using stock_app_api.Models;
using stock_app_api.Repositories.IRepository;
using stock_app_api.ViewModels;
using stock_app_api.ViewModels.DTOs;
using System.Diagnostics.Metrics;
using System.IdentityModel.Tokens.Jwt;
using System.Numerics;
using System.Security.Claims;
using System.Text;

namespace stock_app_api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly StockAppContext _db;
        private readonly JwtConfig _jwtConfig;
        public UserRepository(StockAppContext db, IOptions<JwtConfig> jwtConfig)
        {
            _db = db;
            _jwtConfig = jwtConfig.Value;
        }
        public async Task<UserDTO> Create(RegisterVM registerVM)
        {
            //Call procedure SQL
            IEnumerable<User> users = await _db.Users.FromSqlRaw(
                "EXEC dbo.RegisterUser @username, @password, @email, @phone, @fullName, @dateOfBirth, @country, @role",
                new SqlParameter("@username", registerVM.Username ?? ""),
                new SqlParameter("@password", registerVM.Password),
                new SqlParameter("@email", registerVM.Email),
                new SqlParameter("@phone", registerVM.Phone ?? ""),
                new SqlParameter("@fullName", registerVM.FullName ?? ""),
                new SqlParameter("@dateOfBirth", (object) registerVM.DateOfBirth ?? DBNull.Value),
                new SqlParameter("@country", registerVM.Country ?? ""),
                new SqlParameter("@role", registerVM.Role ?? "")
            ).ToListAsync();
            User? user = users.FirstOrDefault();
            return getToken(user);
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetById(int id)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<User?> GetByUserName(string username)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.UserName == username);
        }

        public async Task<UserDTO> Login(LoginViewModel loginViewModel)
        {
            IEnumerable<User> users = await _db.Users.FromSqlRaw(
                "EXEC dbo.CheckLogin @email, @password",
                new SqlParameter("@email", loginViewModel.Email),
                new SqlParameter("@password", loginViewModel.Password)
            ).ToListAsync();
            User? user = users.FirstOrDefault();
            return getToken(user);
        }
        private UserDTO getToken(User user)
        {
            if (user != null)
            {
                //Create JWT
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_jwtConfig.SecretKey);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                        new Claim(ClaimTypes.Role, user.Role??"User")
                    }),
                    Expires = DateTime.UtcNow.AddDays(2),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature
                )
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                String jwt = tokenHandler.WriteToken(token);
                return new UserDTO
                {
                    UserName = user.UserName,
                    IsAdmin = (user.Role == "Admin"),
                    Key = jwt
                };
            }
            else
            {
                throw new ArgumentException("Email or password invalid!");
            }
        }
    }
}
