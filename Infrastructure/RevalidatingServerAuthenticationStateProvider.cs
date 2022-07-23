using DatingApp.FrontEnd.Models.CurrentUser;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;

namespace DatingApp.FrontEnd.Infrastructure
{
    public class RevalidatingIdentityAuthenticationStateProvider<TUser> : RevalidatingServerAuthenticationStateProvider where TUser : class
    {
        private readonly ICurrentUser _currentUser;

        public RevalidatingIdentityAuthenticationStateProvider(ILoggerFactory loggerFactory, ICurrentUser currentUser) : base(loggerFactory)
        {
            _currentUser = currentUser;
        }

        protected override TimeSpan RevalidationInterval => TimeSpan.FromSeconds(60); // Reevalidation every 1 min

        protected override Task<bool> ValidateAuthenticationStateAsync(AuthenticationState authenticationState, CancellationToken cancellationToken)
        {
            return _currentUser.IsLoggedIn();
        }
    }
}
