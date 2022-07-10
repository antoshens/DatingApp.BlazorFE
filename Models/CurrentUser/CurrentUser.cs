using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DatingApp.FrontEnd.Models.CurrentUser
{
    public class CurrentUser : ICurrentUser
    {
        public bool IsLoggedIn { get; private set; }

        public string FirstName { get; private set; }

        public ClaimsPrincipal ClaimsPrincipal { get; private set; }

        public void SetCurrentUser(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);

            FirstName = jwtSecurityToken.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.NameId)?.Value;

            var expires = jwtSecurityToken.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Exp)?.Value;
            if (!string.IsNullOrEmpty(expires) && int.TryParse(expires, out var tokenExpiryDate))
            {
                var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                dateTime = dateTime.AddSeconds(tokenExpiryDate).ToLocalTime();

                IsLoggedIn = dateTime > DateTime.UtcNow;

                var identity = new ClaimsIdentity(
                    jwtSecurityToken.Claims,
                    Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme
                );
                ClaimsPrincipal = new ClaimsPrincipal(identity);
            }
        }
    }
}
