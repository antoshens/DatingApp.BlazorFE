using System.ComponentModel.DataAnnotations;

namespace DatingApp.FrontEnd.Models
{
    public class RegisterUser
    {
        [Required(ErrorMessage = "First name is required")]
        public string FirstName {get; set;} = string.Empty;

        [Required(ErrorMessage = "Last name is required")]
        public string LastName {get; set;} = string.Empty;

        public string UserName {get; set;} = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email {get; set;} = string.Empty;

        public DateOnly DateOfBirth { get; set; } = DateOnly.FromDateTime(DateTime.Now.Date);

        public Gender Gender { get; set; } = Gender.NotSpecified;

        [Required(ErrorMessage = "Passwrod is required")]
        public string Password {get; set;} = string.Empty;

        [Required(ErrorMessage = "You should repeat your password")]
        [Compare(nameof(Password), ErrorMessage = "Passwords should be identical")]
        public string RepeatPassword { get; set; } = string.Empty;

        public string Interests { get; set; } = string.Empty;

        //public string LookingFor { get; set; } = string.Empty;
        //IEnumerable<PhotoDto> Photos,

        public string City { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;
    }
}
