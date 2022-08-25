namespace DatingApp.FrontEnd.Gateway.GatewayModels
{
    public record class UserLoginGateway(string UserName, string Password);

    public record class LoggedUserGateway(string UserName, string Token);

    public record class UserGateway(string UserName,
        string Password,
        string Interests,
        byte LookingFor,
        string City,
        string Country,
        string? FirstName,
        string? LastName,
        string Email,
        DateTime BirthDate,
        byte Sex
    );

    public record class UserAccountGateway(string UserName,
        string Password,
        string Interests,
        LookingFor LookingFor,
        string City,
        string Country,
        IEnumerable<UserPhoto> Photos,
        string? FirstName,
        string? LastName,
        string Email,
        DateTime BirthDate,
        byte Sex
    );

    public record class UserAccountGeneralInfoGateway(string UserName,
        LookingFor LookingFor,
        string City,
        string Country,
        string? FirstName,
        string? LastName,
        string Email,
        DateTime BirthDate,
        byte Sex);
}
