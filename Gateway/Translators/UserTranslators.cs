namespace DatingApp.FrontEnd.Gateway.Translators
{
    public class UserTranslators : IModelTranslator<UserLoginGateway, UserLogin>,
        IModelTranslator<UserGateway, RegisterUser>
    {
        public UserLoginGateway GetGatewayModel(UserLogin model) => new (model.Login, model.Password);

        public UserGateway GetGatewayModel(RegisterUser model) => new(model.Email, model.Password,
            model.Interests, (byte)model.LookingFor, model.City, model.Country, model.FirstName,
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
            LastName = model.LastName,
            DateOfBirth = DateOnly.FromDateTime(model.BirthDate),
            Interests = model.Interests,
            Password = model.Password,
            Gender = (Gender)model.Sex,
            LookingFor = (LookingFor)model.LookingFor,
            City = model.City,
            Country = model.Country,
        };
    }
}
