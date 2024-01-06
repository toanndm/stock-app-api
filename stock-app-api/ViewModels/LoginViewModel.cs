using System.ComponentModel.DataAnnotations;

namespace stock_app_api.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public String? Email { get; set; }
        [Required]
        public String? Password { get; set; }
    }
}
