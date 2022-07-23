namespace DatingApp.FrontEnd.Gateway.DotNetGateway
{
    public interface IMemberGateway
    {
        Task<IEnumerable<Member>> GetAllMembersAsync(int skip, int take);
    }
}
