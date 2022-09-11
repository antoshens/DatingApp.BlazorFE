using Microsoft.AspNetCore.Components.Forms;

namespace DatingApp.FrontEnd.Gateway.DotNetGateway
{
    public class GatewayAdapter
    {
        private readonly IUserGateway _userGateway;
        private readonly IMemberGateway _memberGateway;
        private readonly IPhotoGateway _photoGateway;

        public GatewayAdapter(
            IUserGateway userGateway,
            IMemberGateway memberGateway,
            IPhotoGateway photoGateway)
        {
            _userGateway = userGateway;
            _memberGateway = memberGateway;
            this._photoGateway = photoGateway;
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

        public async Task<int> LikeUserAsync(int userId)
        {
            return await _memberGateway.LikeMemberAsync(userId);
        }

        public async Task<int> DislikeUserAsync(int userId)
        {
            return await _memberGateway.DislikeMemberAsync(userId);
        }

        public async Task<UserAccount?> GetUserAccount()
        {
            var response = await _userGateway.GetUserDetails();

            if (response is null)
            {
                return null;
            }

            var translator = new UserTranslators();
            var userAccount = translator.GetModel(response);

            return userAccount;
        }

        public async Task<UserAccount?> UpdateUserAccount<T>(T model) where T : class
        {
            var translator = new UserTranslators();
            UserAccountGateway response;

            if (typeof(T) == typeof(UserAccountGeneralInfo))
            {
                var gatewayModel = translator.GetGatewayModel(model as UserAccountGeneralInfo);
                var accountPatch = new PatchModel<UserAccountGeneralInfoGateway>(gatewayModel);

                response = await _userGateway.UpdateUserDetails(accountPatch);
            }
            else
            {
                var accountPatch = new PatchModel<T>(model);

                response = await _userGateway.UpdateUserDetails(accountPatch);
            }

            if (response is null)
            {
                return null;
            }
            var userAccount = translator.GetModel(response);

            return userAccount;
        }

        public async Task<List<string>> ChangeUserPassword(ChangePasswordModel model)
        {
            return await _userGateway.UpdatePassword(model);
        }

        public async Task<int> DeleteUserAccount()
        {
            return await _userGateway.DeleteUserDetails();
        }

        public async Task UploadPhoto(IBrowserFile photoFile, bool isMain)
        {
            await _photoGateway.UploadNewPhoto(photoFile, isMain);
        }

        public async Task<IEnumerable<UserPhoto>> GetUserPhotos(int userId)
        {
            return await _photoGateway.GetUserPhotos(userId);
        }

        public async Task<IEnumerable<UserPhoto>> GetCurrentUserPhotos()
        {
            return await _photoGateway.GetUserPhotos(null);
        }

        public async Task<UserPhoto> DeleteUserPhoto(UserPhoto photo)
        {
            return await _photoGateway.DeletePhoto(photo);
        }

        public async Task<UserPhoto> MarkPhotoAsMain(UserPhoto photo)
        {
            return await _photoGateway.MarkAsMain(photo);
        }

        public async Task<IEnumerable<Member>> GetLikedMembers(int skip, int take)
        {
            return await _memberGateway.GetLikedMembersAsync(skip, take);
        }

        public async Task<int> GetLikedMemberCount()
        {
            return await _memberGateway.GetLikedMemberCountAsync();
        }
    }
}
