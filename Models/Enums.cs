using System.ComponentModel.DataAnnotations;

namespace DatingApp.FrontEnd.Models
{
    public enum Gender
    {
        Male = 0,
        Female = 1,
        [Display(Name = "Non binary")]
        NonBinary = 2,
        Other = 3,
        [Display(Name = "Not specified")]
        NotSpecified = 4
    }
}
