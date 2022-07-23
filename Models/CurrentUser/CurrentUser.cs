using Microsoft.JSInterop;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DatingApp.FrontEnd.Models.CurrentUser
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IJSRuntime _jsRuntime;

        public CurrentUser(IJSRuntime jsRuntime)
        {
            this._jsRuntime = jsRuntime;
        }

        public async Task<bool> IsLoggedIn()
        {
            var tokenValue = await _jsRuntime.InvokeAsync<string>("ReadToken.ReadToken", "AUTH-TOKEN");

            if (string.IsNullOrEmpty(tokenValue)) return false;

            var handler = new JwtSecurityTokenHandler();
            var jwsToken = handler.ReadJwtToken(tokenValue);

            var expires = jwsToken.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Exp)?.Value;
            if (!string.IsNullOrEmpty(expires) && int.TryParse(expires, out var tokenExpiryDate))
            {
                var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                dateTime = dateTime.AddSeconds(tokenExpiryDate).ToLocalTime();

                return dateTime > DateTime.UtcNow;
            }

            return false;
        }

        public async Task<string> GetFirstName()
        {
            var tokenValue = await _jsRuntime.InvokeAsync<string>("ReadToken.ReadToken", "AUTH-TOKEN");

            if (string.IsNullOrEmpty(tokenValue)) return string.Empty;

            var handler = new JwtSecurityTokenHandler();
            var jwsToken = handler.ReadJwtToken(tokenValue);

            return jwsToken.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.NameId)?.Value ?? string.Empty;
        }

        public async Task<string> GetToken()
        {
            var tokenValue = await _jsRuntime.InvokeAsync<string>("ReadToken.ReadToken", "AUTH-TOKEN");

            if (string.IsNullOrEmpty(tokenValue)) return string.Empty;

            var handler = new JwtSecurityTokenHandler();
            var jwsToken = handler.ReadJwtToken(tokenValue);

            return jwsToken.RawData;
        }

        public async Task<ClaimsPrincipal> GetClaimsPrincipal(string? token = null)
        {
            var handler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwsToken;

            if (!string.IsNullOrEmpty(token))
            {
                jwsToken = handler.ReadJwtToken(token);
            }
            else
            {
                var tokenValue = await _jsRuntime.InvokeAsync<string>("ReadToken.ReadToken", "AUTH-TOKEN");

                if (string.IsNullOrEmpty(tokenValue)) return new ClaimsPrincipal();

                jwsToken = handler.ReadJwtToken(tokenValue);
            }

            var identity = new ClaimsIdentity(
                jwsToken.Claims,
                Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme
            );

            return new ClaimsPrincipal(identity);
        }
    }
}
