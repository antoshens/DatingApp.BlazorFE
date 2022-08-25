namespace DatingApp.FrontEnd.Gateway.DotNetGateway
{
    public interface IHttpClientService
    {
        Task<TResponse?> SendPostAsync<TResponse, TRequest>(string url, TRequest? model, bool isAnonymous = false);
        Task<TResponse?> SendPostAsync<TResponse>(string url, bool isAnonymous = false);
        Task<TResponse?> SendGetAsync<TResponse>(string url, bool isAnonymous = false);
        Task<TResponse?> SendPutAsync<TResponse, TRequest>(string url, TRequest? model, bool isAnonymous = false);
        Task<TResponse?> SendPatchAsync<TResponse, TRequest>(string url, PatchModel<TRequest> model, bool isAnonymous = false) where TRequest : class;
        Task<TResponse?> SendDeleteAsync<TResponse>(string url, bool isAnonymous = false);
    }
}
