namespace DatingApp.FrontEnd.Gateway.Translators
{
    public class UserTranslators : IModelTranslator<UserLoginGateway, UserLogin>,
        IModelTranslator<UserGateway, RegisterUser>
    {
        public UserLoginGateway GetGatewayModel(UserLogin model) => new (model.Login, model.Password);

        public UserGateway GetGatewayModel(RegisterUser model) => new(model.UserName, model.Password,
            model.Interests, "", model.City, model.Country, model.FirstName,
            model.LastName, model.Email, model.DateOfBirth.ToDateTime(new TimeOnly()), (byte)model.Gender);

        public UserLogin GetModel(UserLoginGateway model) => new UserLogin
        {
            Login = model.UserName,
            Password = model.Password
        };

        public RegisterUser GetModel(UserGateway model) => new RegisterUser
        {
            UserName = model.UserName,
            Email = model.Email,
            FirstName = model.FirstName,
            DateOfBirth = DateOnly.FromDateTime(model.BirthDate),
            Interests = model.Interests,
            Password = model.Password,
            Gender = (Gender)model.Sex,
            City = model.City,
            Country = model.Country,
        };
    }
}
