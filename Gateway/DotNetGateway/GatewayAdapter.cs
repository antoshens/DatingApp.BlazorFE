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
    }
}
