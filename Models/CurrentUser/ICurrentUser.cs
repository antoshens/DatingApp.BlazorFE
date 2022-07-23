using System.Security.Claims;

namespace DatingApp.FrontEnd.Models.CurrentUser
{
    public interface ICurrentUser
    {
        Task<bool> IsLoggedIn();
        Task<string> GetFirstName();
        Task<string> GetToken();
        Task<ClaimsPrincipal> GetClaimsPrincipal(string? token = null);
    }
}
