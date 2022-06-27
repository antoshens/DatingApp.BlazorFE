namespace DatingApp.FrontEnd.Gateway.DotNetGateway
{
    public interface IUserGateway
    {
        Task<LoggedUserGateway?> LoginAsync(UserLoginGateway login);
        Task<GatewayModels.UserGateway?> RegisterAsync(GatewayModels.UserGateway user);
    }
}
