using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace stock_app_api.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("user_id")]
        public int UserId { get; set; }

        [Required]
        [Column("user_name")]
        [MaxLength(100)]
        public string UserName { get; set; } = "";

        [Required]
        [Column("hashed_password")]
        [MaxLength(200)]
        public string HashedPassword { get; set; } = "";

        [Required]
        [Column("email")]
        [MaxLength(200)]
        public string Email { get; set; } = "";

        [Required]
        [Column("phone")]
        [MaxLength(20)]
        public string Phone { get; set; } = "";

        [Column("full_name")]
        [MaxLength(100)]
        public string FullName { get; set; } = "";

        [Column("date_of_birth")]
        public DateTime? DateOfBirth { get; set; }

        [Column("country")]
        [MaxLength(100)]
        public string Country { get; set; } = "";
    }
}
