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

        public async Task<IEnumerable<Member>> GetLikedMembersAsync(int skip, int take) =>
            await _httpClientService.SendGetAsync<IEnumerable<Member>>($"user/likedUsers?skip={skip}&take={take}") ?? Enumerable.Empty<Member>();

        public async Task<int> GetLikedMemberCountAsync() => await _httpClientService.SendGetAsync<int>($"user/likedUsersCount");

        public async Task<int> LikeMemberAsync(int userId) => await _httpClientService.SendPostAsync<int>($"user/likeUser/{userId}");

        public async Task<int> DislikeMemberAsync(int userId) => await _httpClientService.SendPostAsync<int>($"user/unlikeUser/{userId}");
    }
}
