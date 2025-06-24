using System.ComponentModel.DataAnnotations;

namespace LibrarySystemWeb.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        public string Email { get; set; } = string.Empty;
        public int? UserId{ get; set; } = null;
        public string? UserType{ get; set; } = "USER";

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;
    }
}

