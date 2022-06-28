using System.ComponentModel.DataAnnotations;

namespace DatingApp.FrontEnd.Models.Validation
{
    public class DateRangeAttribute : ValidationAttribute
    {
        private readonly int _minAge;

        public DateRangeAttribute(int MinAge)
        {
            _minAge = MinAge;
        }

        public DateRangeAttribute(int MinAge, string ErrorMessage) : base(ErrorMessage)
        {
            _minAge = MinAge;
        }

        public override bool IsValid(object value)
        {
            return (DateOnly)value <= DateOnly.FromDateTime(DateTime.Today.AddYears(-_minAge).Date);
        }
    }
}
