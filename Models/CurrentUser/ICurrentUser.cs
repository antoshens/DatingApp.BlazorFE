using System.Security.Claims;

namespace DatingApp.FrontEnd.Models.CurrentUser
{
    public interface ICurrentUser
    {
        Task<bool> IsLoggedInAsync();
        Task<string> GetFirstNameAsync();
        Task<string> GetTokenAsync();
        Task<ClaimsPrincipal> GetClaimsPrincipalAsync(string? token = null);
    }
}
