namespace DatingApp.FrontEnd.Gateway.DotNetGateway
{
    public class UserGateway : IUserGateway
    {
        private readonly IHttpClientService _httpClientService;

        public UserGateway(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<int> DeleteUserDetails() => await _httpClientService.SendDeleteAsync<int>("user");

        public async Task<UserAccountGateway?> GetUserDetails() => await _httpClientService.SendGetAsync<UserAccountGateway>("user");

        public async Task<LoggedUserGateway?> LoginAsync(UserLoginGateway login) =>
            await _httpClientService.SendPostAsync<LoggedUserGateway, UserLoginGateway>("auth/login", login, true);

        public async Task<GatewayModels.UserGateway?> RegisterAsync(GatewayModels.UserGateway user) =>
            await _httpClientService.SendPostAsync<GatewayModels.UserGateway, GatewayModels.UserGateway>("auth/register", user, true);

        public async Task<UserAccountGateway?> UpdateUserDetails(UserAccountGateway account) =>
            await _httpClientService.SendPutAsync<UserAccountGateway, UserAccountGateway>("user", account);
    }
}
