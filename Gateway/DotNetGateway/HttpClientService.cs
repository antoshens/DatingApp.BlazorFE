using DatingApp.FrontEnd.Gateway.Configuration;
using Newtonsoft.Json;

namespace DatingApp.FrontEnd.Gateway.DotNetGateway
{
    public class HttpClientService : IHttpClientService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<HttpClientService> _logger;
        private readonly ApiOptions _options;

        public HttpClientService(IHttpClientFactory httpClientFactory,
            ILogger<HttpClientService> logger,
            ApiOptions options)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _options = options;
        }

        public Task<TResponse?> SendDeleteAsync<TResponse, TRequest>(string url, TRequest? model, bool isAnonymous = false) where TResponse : class
        {
            throw new NotImplementedException();
        }

        public Task<TResponse?> SendGetAsync<TResponse>(string url, bool isAnonymous = false) where TResponse : class
        {
            throw new NotImplementedException();
        }

        public async Task<TResponse?> SendPostAsync<TResponse, TRequest>(string url, TRequest? model, bool isAnonymous = false) where TResponse : class
        {
            try
            {
                var fullUrl = $"/api/{url}";
                HttpClient httpClient = _httpClientFactory.CreateClient("datingapp");

                string content;
                HttpResponseMessage response;

                if (model != null)
                {
                    content = JsonConvert.SerializeObject(model);

                    _logger.LogInformation($"Sending POST request to {_options.BaseUrl}{fullUrl} with body {content}.");

                    response = await httpClient.PostAsJsonAsync(fullUrl, content);
                }
                else
                {
                    _logger.LogInformation($"Sending POST request to {_options.BaseUrl}{fullUrl}.");

                    response = await httpClient.PostAsync(fullUrl, null);
                }


                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var responseModel = JsonConvert.DeserializeObject<TResponse>(jsonResponse);

                    _logger.LogInformation($"Reply POST {_options.BaseUrl}{fullUrl} - {jsonResponse}.");

                    return responseModel;
                }

                return null;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"Gateway server returns exception with HTTP code: {ex.StatusCode} and message {ex.Message}.");

#if DEBUG
                _logger.LogDebug($"Exception details: {ex.Message}{Environment.NewLine}{ex.Data}");
#endif

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unknown exception has been occured: {ex.Message}.");

#if DEBUG
                _logger.LogDebug($"Exception details: {ex.Message}{Environment.NewLine}{ex.Data}");
#endif

                return null;
            }
        }
    }
}
