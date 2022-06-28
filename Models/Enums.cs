using System.ComponentModel.DataAnnotations;

namespace DatingApp.FrontEnd.Models
{
    public enum Gender
    {
        [Display(Name = "Not specified")]
        NotSpecified = 0,
        Male = 1,
        Female = 2,
        [Display(Name = "Non binary")]
        NonBinary = 3,
    }

    public enum LookingFor
    {
        [Display(Name = "Any gender")]
        Both = 0,
        Male = 1,
        Female = 2,
        [Display(Name = "Non binary")]
        NonBinary = 3,
    }
}
