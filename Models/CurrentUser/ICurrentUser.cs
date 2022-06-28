namespace DatingApp.FrontEnd.Models.CurrentUser
{
    public interface ICurrentUser
    {
        bool IsLoggedIn { get; }
        string FirstName { get; }
        void SetCurrentUser(string token);
    }
}
