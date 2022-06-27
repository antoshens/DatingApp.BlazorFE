namespace DatingApp.FrontEnd.Gateway.GatewayModels
{
    public record class UserLoginGateway(string UserName, string Password);

    public record class LoggedUserGateway(string UserName, string Token);

    public record class UserGateway(string UserName,
        string Password,
        string Interests,
        string LookingFor,
        string City,
        string Country,
        //IEnumerable<PhotoDto> Photos,
        string? FirstName,
        string? LastName,
        string Email,
        DateTime BirthDate,
        byte Sex
    );
}
