namespace stock_app_api.ViewModels.DTOs
{
    public class NotificationDTO
    {
        public int? UserId { get; set; }

        public string? NotificationType { get; set; }

        public string Content { get; set; } = null!;

        public bool? IsRead { get; set; }
    }
}
