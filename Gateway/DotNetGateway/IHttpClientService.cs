namespace DatingApp.FrontEnd.Gateway.DotNetGateway
{
    public interface IHttpClientService
    {
        Task<TResponse?> SendPostAsync<TResponse, TRequest>(string url, TRequest? model, bool isAnonymous = false) where TResponse : class;
        Task<TResponse?> SendGetAsync<TResponse>(string url, bool isAnonymous = false) where TResponse : class;
        Task<TResponse?> SendDeleteAsync<TResponse, TRequest>(string url, TRequest? model, bool isAnonymous = false) where TResponse : class;
    }
}
