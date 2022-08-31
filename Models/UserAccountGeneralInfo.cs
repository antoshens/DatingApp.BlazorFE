using DatingApp.FrontEnd.Models.Validation;
using System.ComponentModel.DataAnnotations;

namespace DatingApp.FrontEnd.Models
{
    public class UserAccountGeneralInfo
    {
        public UserAccountGeneralInfo()
        {
        }

        public UserAccountGeneralInfo(UserAccount userAccount)
        {
            UserName = userAccount.UserName;
            FirstName = userAccount.FirstName;
            LastName = userAccount.LastName;
            LookingFor = userAccount.LookingFor;
            City = userAccount.City;
            Country = userAccount.Country;
            Email = userAccount.Email;
            BirthDate = userAccount.BirthDate;
            Gender = userAccount.Gender;
        }

        [Required]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Please fill in your First Name")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Please fill in your last Name")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Please fill in you love preferences")]
        public LookingFor LookingFor { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Required(ErrorMessage = "Please fill in you Email")]
        public string Email { get; set; }

        [DateRange(18, ErrorMessage = "You should be older than 18 y. o.")]
        public DateOnly BirthDate { get; set; } = DateOnly.FromDateTime(DateTime.Now.Date);

        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }
    }
}
