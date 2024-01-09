using Microsoft.Identity.Client;

namespace stock_app_api.ViewModels.DTOs
{
    public class UserDTO
    {
        public string? UserName { get; set; }
        public Boolean IsAdmin { get; set; }
        public string? Key { get; set; }
    }
}
