using stock_app_api.ViewModels;

namespace stock_app_api.Services.IServices
{
    public interface IOrderService
    {
        Task<OrderViewModel> PlaceOrder(OrderViewModel orderViewModel, int userId);
        Task<List<OrderViewModel>?> GetOrders(int userId, int page, int limit);
    }
}
