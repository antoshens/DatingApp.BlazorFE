using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace DatingApp.FrontEnd.Models.CurrentUser
{
    public class CurrentUser : ICurrentUser
    {
        private readonly ProtectedSessionStorage _protectedSessionStore;

        public CurrentUser(ProtectedSessionStorage protectedSessionStore)
        {
            _protectedSessionStore = protectedSessionStore;
        }

        public async Task<bool> IsLoggedInAsync()
        {
            var tokenValue = await _protectedSessionStore.GetAsync<string>("AUTH-TOKEN");

            if (string.IsNullOrEmpty(tokenValue.Value)) return false;

            var handler = new JwtSecurityTokenHandler();
            var jwsToken = handler.ReadJwtToken(tokenValue.Value);

            var expires = jwsToken.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Exp)?.Value;
            if (!string.IsNullOrEmpty(expires) && int.TryParse(expires, out var tokenExpiryDate))
            {
                var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                dateTime = dateTime.AddSeconds(tokenExpiryDate).ToLocalTime();

                return dateTime > DateTime.UtcNow;
            }

            return false;
        }

        public async Task<string> GetFirstNameAsync()
        {
            var tokenValue = await _protectedSessionStore.GetAsync<string>("AUTH-TOKEN");

            if (string.IsNullOrEmpty(tokenValue.Value)) return string.Empty;

            var handler = new JwtSecurityTokenHandler();
            var jwsToken = handler.ReadJwtToken(tokenValue.Value);

            return jwsToken.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.NameId)?.Value ?? string.Empty;
        }

        public async Task<string> GetTokenAsync()
        {
            var tokenValue = await _protectedSessionStore.GetAsync<string>("AUTH-TOKEN");

            if (string.IsNullOrEmpty(tokenValue.Value)) return string.Empty;

            var handler = new JwtSecurityTokenHandler();
            var jwsToken = handler.ReadJwtToken(tokenValue.Value);

            return jwsToken.RawData;
        }

        public async Task<ClaimsPrincipal> GetClaimsPrincipalAsync(string? token = null)
        {
            var handler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwsToken;

            if (!string.IsNullOrEmpty(token))
            {
                jwsToken = handler.ReadJwtToken(token);
            }
            else
            {
                var tokenValue = await _protectedSessionStore.GetAsync<string>("AUTH-TOKEN");

                if (string.IsNullOrEmpty(tokenValue.Value)) return new ClaimsPrincipal();

                jwsToken = handler.ReadJwtToken(tokenValue.Value);
            }

            var identity = new ClaimsIdentity(
                jwsToken.Claims,
                Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme
            );

            return new ClaimsPrincipal(identity);
        }
    }
}
