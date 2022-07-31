namespace DatingApp.FrontEnd.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Interests { get; set; }
        public LookingFor LookingFor { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public IEnumerable<UserPhoto> Photos { get; set; }
    }
}
