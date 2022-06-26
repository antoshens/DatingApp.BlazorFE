using System.ComponentModel.DataAnnotations;

namespace DatingApp.FrontEnd.Models
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Username is required")]
        public string Login {get; set;} = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        public string Password {get; set;} = string.Empty;
    }
}
