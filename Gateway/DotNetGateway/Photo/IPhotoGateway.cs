using Microsoft.AspNetCore.Components.Forms;

namespace DatingApp.FrontEnd.Gateway.DotNetGateway
{
    public interface IPhotoGateway
    {
        Task UploadNewPhoto(IBrowserFile file, bool isMain);
        Task<IEnumerable<UserPhoto>> GetUserPhotos(int? userId);
        Task<UserPhoto> DeletePhoto(UserPhoto photo);
        Task<UserPhoto> MarkAsMain(UserPhoto photo);
    }
}
