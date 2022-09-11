namespace DatingApp.FrontEnd.Gateway.DotNetGateway
{
    public interface IMemberGateway
    {
        Task<IEnumerable<Member>> GetAllMembersAsync(int skip, int take);
        Task<int> LikeMemberAsync(int userId);
        Task<int> DislikeMemberAsync(int userId);
        Task<IEnumerable<Member>> GetLikedMembersAsync(int skip, int take);
        Task<int> GetLikedMemberCountAsync();
    }
}
