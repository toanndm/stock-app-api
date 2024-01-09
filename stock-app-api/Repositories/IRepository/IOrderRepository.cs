using stock_app_api.Models;
using stock_app_api.ViewModels;

namespace stock_app_api.Repositories.IRepository
{
    public interface IOrderRepository
    {
        Task<Order> PlaceOrder(Order order);
        Task<List<Order>?> GetOrders(int userId, int page, int limit);
    }
}
