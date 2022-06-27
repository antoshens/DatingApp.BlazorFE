namespace DatingApp.FrontEnd.Gateway.DotNetGateway
{
    public class GatewayAdapter : UserGateway
    {
        public GatewayAdapter(IHttpClientService httpClientService) : base(httpClientService)
        {
        }

        public async Task<LoggedUserGateway?> LoginAsync(UserLogin login)
        {
            var userLoginGateway = new UserTranslators().GetGatewayModel(login);

            var response = await LoginAsync(userLoginGateway);

            return response;
        }

        public async Task<RegisterUser?> RegisterAsync(RegisterUser login)
        {
            var translator = new UserTranslators();
            var userLoginGateway = translator.GetGatewayModel(login);

            var response = await RegisterAsync(userLoginGateway);

            return response != null ? translator.GetModel(response) : null;
        }
    }
}
