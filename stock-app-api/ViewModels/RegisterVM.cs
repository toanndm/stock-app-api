using System.ComponentModel.DataAnnotations;

namespace stock_app_api.ViewModels
{
    public class RegisterVM
    {
        public String? Username { get; set; }
        [Required]
        [EmailAddress]
        public String? Email {  get; set; }
        [Required]
        public String? Password { get; set; }
        public String? PasswordConfirmation { get; set; }
        public String? Phone { get; set; }
        public String? FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public String? Country { get; set; }
        public String Role { get; set; } = "User";
    }
}
