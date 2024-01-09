using stock_app_api.ViewModels.DTOs;

namespace stock_app_api.Services.IServices
{
    public interface INotificationService
    {
        Task<IEnumerable<NotificationDTO>> GetNotifications(int userId, int page, int limit);
    }
}
