using Azure;
using stock_app_api.Models;
using stock_app_api.Repositories.IRepository;
using stock_app_api.Services.IServices;
using stock_app_api.ViewModels;
using System.Security.Claims;

namespace stock_app_api.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<OrderViewModel> PlaceOrder(OrderViewModel orderViewModel, int userId)
        {
            if (orderViewModel.Quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than 0");
            }
            
            Order order = new Order
            {
                UserId = userId,
                StockId = orderViewModel.StockId,
                OrderType = orderViewModel.OrderType,
                Direction = orderViewModel.Direction,
                Quantity = orderViewModel.Quantity,
                Price = orderViewModel.Price,
                Status = orderViewModel.Status,
                OrderDate = DateTime.Now
            };
            Order response = await _orderRepository.PlaceOrder(order);
            return new OrderViewModel
            {
                StockId = response.StockId,
                OrderType = response.OrderType,
                Direction = response.Direction,
                Quantity = response.Quantity,
                Price = response.Price,
                Status = response.Status,
                OrderDate = response.OrderDate
            };
        }

        public async Task<List<OrderViewModel>?> GetOrders(int userId, int page, int limit)
        {
            var orders = await _orderRepository.GetOrders(userId, page, limit);
            List<OrderViewModel> orderViewModels = orders.Select(order => new OrderViewModel
            {
                StockId = order.StockId,
                OrderType = order.OrderType,
                Direction = order.Direction,
                Quantity = order.Quantity,
                Price = order.Price,
                Status = order.Status,
                OrderDate = order.OrderDate
            }).ToList();
            return orderViewModels;
        }
    }
}
