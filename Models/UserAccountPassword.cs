using System.ComponentModel.DataAnnotations;

namespace DatingApp.FrontEnd.Models
{
    public class UserAccountPassword
    {
        [Required(ErrorMessage = "Please enter your old password")]
        public string OldPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please fill in your password")]
        [StringLength(64, MinimumLength = 6)]
        public string Password { get; set; }

        [Required(ErrorMessage = "You should repeat your password")]
        [Compare(nameof(Password), ErrorMessage = "Passwords should be identical")]
        public string RepeatPassword { get; set; } = string.Empty;
    }
}
