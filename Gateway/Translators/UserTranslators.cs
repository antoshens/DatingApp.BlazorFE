namespace DatingApp.FrontEnd.Gateway.Translators
{
    public class UserTranslators : IModelTranslator<UserLoginGateway, UserLogin>,
        IModelTranslator<UserGateway, RegisterUser>
    {
        public UserLoginGateway GetGatewayModel(UserLogin model) => new(model.Login, model.Password);

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

        public UserAccount GetModel(UserAccountGateway model) => new UserAccount
        {
            UserName = model.UserName,
            Password = model.Password,
            Interests = model.Interests,
            LookingFor = (LookingFor)model.LookingFor,
            City = model.City,
            Country = model.Country,
            Photos = model.Photos,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            BirthDate = DateOnly.FromDateTime(model.BirthDate),
            Gender = (Gender)model.Sex
        };

        public UserAccountGateway GetGatewayModel(UserAccount model) => new(model.UserName, model.Password, model.Interests,
            model.LookingFor, model.City, model.Country, model.Photos, model.FirstName, model.LastName,
            model.Email, model.BirthDate.ToDateTime(new TimeOnly()), (byte)model.Gender);

        public UserAccountGeneralInfoGateway GetGatewayModel(UserAccountGeneralInfo model) => new(model.UserName,
            model.LookingFor, model.City, model.Country, model.FirstName, model.LastName,
            model.Email, model.BirthDate.ToDateTime(new TimeOnly()), (byte)model.Gender);
    }
}
