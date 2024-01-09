using stock_app_api.Models;

namespace stock_app_api.Repositories.IRepository
{
    public interface INotificatonRepository
    {
        Task<List<Notification>> GetNotifications(int userId, int page, int limit);
    }
}
