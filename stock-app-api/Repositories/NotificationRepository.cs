using Microsoft.EntityFrameworkCore;
using stock_app_api.DataAccess;
using stock_app_api.Models;
using stock_app_api.Repositories.IRepository;

namespace stock_app_api.Repositories
{
    public class NotificationRepository : INotificatonRepository
    {
        private readonly StockAppContext _db;
        public NotificationRepository(StockAppContext db)
        {
            _db = db;
        }
        public async Task<List<Notification>> GetNotifications(int userId, int page, int limit)
        {
            return await _db.Notifications.Where(n => n.UserId == userId)
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToListAsync();
        }
    }
}
