namespace DatingApp.FrontEnd.Gateway.DotNetGateway
{
    public class GatewayAdapter
    {
        private readonly IUserGateway _userGateway;
        private readonly IMemberGateway _memberGateway;

        public GatewayAdapter(
            IUserGateway userGateway,
            IMemberGateway memberGateway)
        {
            _userGateway = userGateway;
            _memberGateway = memberGateway;
        }

        public async Task<LoggedUserGateway?> LoginAsync(UserLogin login)
        {
            var userLoginGateway = new UserTranslators().GetGatewayModel(login);

            var response = await _userGateway.LoginAsync(userLoginGateway);

            return response;
        }

        public async Task<RegisterUser?> RegisterAsync(RegisterUser login)
        {
            var translator = new UserTranslators();
            var userLoginGateway = translator.GetGatewayModel(login);

            var response = await _userGateway.RegisterAsync(userLoginGateway);

            return response != null ? translator.GetModel(response) : null;
        }

        public async Task<IEnumerable<Member>> GetAllMembersAsync(int skip, int take)
        {
            var response = await _memberGateway.GetAllMembersAsync(skip, take);

            return response;
        }

        public async Task<int> LikeUserAsync(int userId)
        {
            return await _memberGateway.LikeMemberAsync(userId);
        }

        public async Task<int> DislikeUserAsync(int userId)
        {
            return await _memberGateway.DislikeMemberAsync(userId);
        }

        public async Task<UserAccount?> GetUserAccount()
        {
            var response = await _userGateway.GetUserDetails();

            if (response is null)
            {
                return null;
            }

            var translator = new UserTranslators();
            var userAccount = translator.GetModel(response);

            return userAccount;
        }

        public async Task<UserAccount?> UpdateUserAccount(UserAccount account)
        {
            var translator = new UserTranslators();
            var userAccountGateway = translator.GetGatewayModel(account);

            var response = await _userGateway.UpdateUserDetails(userAccountGateway);

            if (response is null)
            {
                return null;
            }
            var userAccount = translator.GetModel(response);

            return userAccount;
        }

        public async Task<int> DeleteUserAccount()
        {
            return await _userGateway.DeleteUserDetails();
        }
    }
}
