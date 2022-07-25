using DatingApp.FrontEnd.Models.CurrentUser;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace DatingApp.FrontEnd.Infrastructure
{
    public class AuthenticationStateHandler : IAuthenticationStateHandler
    {
        private readonly IHostEnvironmentAuthenticationStateProvider _hostAuthentication;
        private readonly ICurrentUser _currentUser;
        private readonly ProtectedSessionStorage _protectedSessionStorage;

        public AuthenticationStateHandler(IHostEnvironmentAuthenticationStateProvider hostAuthentication,
            ICurrentUser currentUser, ProtectedSessionStorage protectedSessionStorage)
        {
            _hostAuthentication = hostAuthentication;
            _currentUser = currentUser;
            _protectedSessionStorage = protectedSessionStorage;
        }

        public async Task UpdateState()
        {
            var claims = await _currentUser.GetClaimsPrincipalAsync();
            _hostAuthentication.SetAuthenticationState(Task.FromResult(new AuthenticationState(claims)));
        }

        public async Task WriteToken(string token)
        {
            await _protectedSessionStorage.SetAsync("AUTH-TOKEN", token);
        }

        public async Task DeleteToken()
        {
            await _protectedSessionStorage.DeleteAsync("AUTH-TOKEN");
        }
    }
}
