using Microsoft.EntityFrameworkCore;
using stock_app_api.DataAccess;
using stock_app_api.Models;
using stock_app_api.Repositories.IRepository;
using stock_app_api.ViewModels;

namespace stock_app_api.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly StockAppContext _db;
        public OrderRepository(StockAppContext db)
        {
            _db = db;
        }

        public async Task<List<Order>?> GetOrders(int userId, int page, int limit)
        {
            return await _db.Orders.Where(o => o.UserId == userId)
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<Order> PlaceOrder(Order order)
        {
            _db.Orders.Add(order);
            await _db.SaveChangesAsync();
            return order;
        }
    }
}
