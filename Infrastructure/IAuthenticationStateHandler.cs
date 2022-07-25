using System.Security.Claims;

namespace DatingApp.FrontEnd.Infrastructure
{
    public interface IAuthenticationStateHandler
    {
        Task UpdateState();
        Task WriteToken(string token);
        Task DeleteToken();
    }
}
