namespace DatingApp.FrontEnd.Gateway.DotNetGateway
{
    public class UserGateway : IUserGateway
    {
        private readonly IHttpClientService _httpClientService;

        public UserGateway(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<LoggedUserGateway?> LoginAsync(UserLoginGateway login)
        {
            var response = await _httpClientService.SendPostAsync<LoggedUserGateway, UserLoginGateway>("auth/login", login, true);
            _httpClientService.SetAuthHeader(response?.Token);
            
            return response;
        }

        public async Task<GatewayModels.UserGateway?> RegisterAsync(GatewayModels.UserGateway user) =>
            await _httpClientService.SendPostAsync<GatewayModels.UserGateway, GatewayModels.UserGateway>("auth/register", user, true);
    }
}
