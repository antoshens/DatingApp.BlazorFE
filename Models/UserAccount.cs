using System.ComponentModel.DataAnnotations;

namespace DatingApp.FrontEnd.Models
{
    public class UserAccount
    {
        [Required(ErrorMessage ="Please fill in your First Name")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Please fill in your last Name")]
        public string? LastName { get; set; }

        [Required(ErrorMessage ="Please fill in your password")]
        [StringLength(64, MinimumLength = 6)]
        public string Password { get; set; }

        [Required(ErrorMessage = "You should repeat your password")]
        [Compare(nameof(Password), ErrorMessage = "Passwords should be identical")]
        public string RepeatPassword { get; set; } = string.Empty;

        public string Interests { get; set; }

        [Required(ErrorMessage = "Please fill in you love preferences")]
        public LookingFor LookingFor { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public IEnumerable<UserPhoto> Photos { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Please fill in you Email")]
        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        [EnumDataType(typeof(Gender))]
        public byte Sex { get; set; }
    }
}
