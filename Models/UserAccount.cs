namespace DatingApp.FrontEnd.Models
{
    public class UserAccount
    {
        public string? UserName { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string OldPassword { get; set; } = string.Empty;

        public string Password { get; set; }

        public string RepeatPassword { get; set; } = string.Empty;

        public string Interests { get; set; }

        public LookingFor LookingFor { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public IEnumerable<UserPhoto> Photos { get; set; }

        public string Email { get; set; }

        public DateOnly BirthDate { get; set; } = DateOnly.FromDateTime(DateTime.Now.Date);

        public Gender Gender { get; set; }
    }
}
