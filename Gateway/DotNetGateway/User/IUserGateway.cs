namespace DatingApp.FrontEnd.Gateway.DotNetGateway
{
    public interface IUserGateway
    {
        Task<LoggedUserGateway?> LoginAsync(UserLoginGateway login);
        Task<GatewayModels.UserGateway?> RegisterAsync(GatewayModels.UserGateway user);
        Task<UserAccountGateway?> GetUserDetails();
        Task<UserAccountGateway?> UpdateUserDetails<T>(PatchModel<T> accountPatch) where T : class;
        Task<List<string>> UpdatePassword(ChangePasswordModel changePasswordModel);
        Task<int> DeleteUserDetails();
    }
}
