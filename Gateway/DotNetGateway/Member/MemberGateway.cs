namespace DatingApp.FrontEnd.Gateway.DotNetGateway
{
    public class MemberGateway : IMemberGateway
    {
        private readonly IHttpClientService _httpClientService;

        public MemberGateway(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<IEnumerable<Member>> GetAllMembersAsync(int skip, int take) =>
            await _httpClientService.SendGetAsync<IEnumerable<Member>>($"user/members?skip={skip}&take={take}") ?? Enumerable.Empty<Member>();
    }
}
