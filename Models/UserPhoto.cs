namespace DatingApp.FrontEnd.Models
{
    public class UserPhoto
    {
        public int PhotoId { get; set; }

        public int UserId { get; set; }

        public string PublicId { get; set; }

        public string Url { get; set; }

        public bool IsMain { get; set; }
    }
}
