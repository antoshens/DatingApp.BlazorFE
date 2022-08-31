using Microsoft.AspNetCore.Components.Forms;

namespace DatingApp.FrontEnd.Gateway.DotNetGateway
{
    public class PhotoGateway : IPhotoGateway
    {
        private readonly IHttpClientService _httpClientService;

        public PhotoGateway(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<UserPhoto> DeletePhoto(UserPhoto photo) =>
            await _httpClientService.SendPostAsync<UserPhoto, UserPhoto>("photo/remove", photo);

        public async Task<IEnumerable<UserPhoto>> GetUserPhotos(int? userId) =>
            await _httpClientService.SendGetAsync<IEnumerable<UserPhoto>>($"photo/userPhotos?userId={userId ?? 0}");

        public async Task<UserPhoto> MarkAsMain(UserPhoto photo) =>
            await _httpClientService.SendPostAsync<UserPhoto, UserPhoto>("photo/markAsMain", photo);

        public async Task UploadNewPhoto(IBrowserFile file, bool isMain) =>
            await _httpClientService.SendFormFileContentPostAsync($"photo/upload/{isMain}", file);
    }
}
