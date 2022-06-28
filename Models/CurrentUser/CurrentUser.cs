using System.IdentityModel.Tokens.Jwt;

namespace DatingApp.FrontEnd.Models.CurrentUser
{
    public class CurrentUser : ICurrentUser
    {
        public bool IsLoggedIn { get; private set; }

        public string FirstName { get; private set; }

        public void SetCurrentUser(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);

            var FirstName = jwtSecurityToken.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.NameId)?.Value;

            var expires = jwtSecurityToken.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Exp)?.Value;
            if (!string.IsNullOrEmpty(expires) && int.TryParse(expires, out var tokenExpiryDate))
            {
                var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                dateTime = dateTime.AddSeconds(1656862571).ToLocalTime();

                IsLoggedIn = dateTime > DateTime.UtcNow;
            }
        }
    }
}
