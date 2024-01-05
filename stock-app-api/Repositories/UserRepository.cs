using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using stock_app_api.DataAccess;
using stock_app_api.Models;
using stock_app_api.Repositories.IRepository;
using stock_app_api.ViewModels;
using System.Diagnostics.Metrics;
using System.Numerics;

namespace stock_app_api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<User?> Create(RegisterVM registerVM)
        {
            //Call procedure SQL
            IEnumerable<User> users = await _db.Users.FromSqlRaw(
                "EXEC dbo.RegisterUser @username, @password, @email, @phone, @fullName, @dateOfBirth, @country",
                new SqlParameter("@username", registerVM.Username ?? ""),
                new SqlParameter("@password", registerVM.Password),
                new SqlParameter("@email", registerVM.Email),
                new SqlParameter("@phone", registerVM.Phone ?? ""),
                new SqlParameter("@fullName", registerVM.FullName ?? ""),
                new SqlParameter("@dateOfBirth", registerVM.DateOfBirth),
                new SqlParameter("@country", registerVM.Country ?? "")
            ).ToListAsync();
            User? user = users.FirstOrDefault();
            return user;
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
    }
}
