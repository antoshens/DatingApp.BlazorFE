using DatingApp.FrontEnd.Models.Validation;
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

        [DateRange(18, ErrorMessage = "You should be older than 18 y. o.")]
        public DateOnly DateOfBirth { get; set; } = DateOnly.FromDateTime(DateTime.Now.Date);

        public Gender Gender { get; set; } = Gender.NotSpecified;

        [Required(ErrorMessage = "Please choose who you're looking for")]
        public LookingFor LookingFor { get; set; }

        [Required(ErrorMessage = "Passwrod is required")]
        public string Password {get; set;} = string.Empty;

        [Required(ErrorMessage = "You should repeat your password")]
        [Compare(nameof(Password), ErrorMessage = "Passwords should be identical")]
        public string RepeatPassword { get; set; } = string.Empty;

        public string Interests { get; set; } = string.Empty;

        public IFormFile MainPhoto { get; set; }

        public bool HasMainPhoto { get => MainPhoto != null; }

        public string City { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;
    }
}
