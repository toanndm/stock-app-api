using stock_app_api.Repositories.IRepository;
using stock_app_api.Services.IServices;
using stock_app_api.ViewModels.DTOs;

namespace stock_app_api.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificatonRepository _notificatonRepository;
        public NotificationService(INotificatonRepository notificatonRepository) 
        { 
            _notificatonRepository = notificatonRepository;
        }
        public async Task<IEnumerable<NotificationDTO>> GetNotifications(int userId, int page, int limit)
        {
            var notifications = await _notificatonRepository.GetNotifications(userId, page, limit);
            var results = notifications.Select(notification => new NotificationDTO
            {
                UserId = notification.UserId,
                NotificationType = notification.NotificationType,
                Content = notification.Content,
                IsRead = notification.IsRead
            });
            return results;
        }
    }
}
