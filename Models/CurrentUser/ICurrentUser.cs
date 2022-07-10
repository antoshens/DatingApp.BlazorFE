using System.Security.Claims;

namespace DatingApp.FrontEnd.Models.CurrentUser
{
    public interface ICurrentUser
    {
        bool IsLoggedIn { get; }
        string FirstName { get; }
        ClaimsPrincipal ClaimsPrincipal { get; }
        void SetCurrentUser(string token);
    }
}
