using DatingApp.FrontEnd.Gateway.Configuration;
using DatingApp.FrontEnd.Models.CurrentUser;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace DatingApp.FrontEnd.Gateway.DotNetGateway
{
    public class HttpClientService : IHttpClientService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ICurrentUser _currentUser;
        private readonly ILogger<HttpClientService> _logger;
        private readonly ApiOptions _options;
        private readonly HttpClient _httpClient;

        public HttpClientService(IHttpClientFactory httpClientFactory,
            ILogger<HttpClientService> logger,
            ApiOptions options,
            ICurrentUser currentUser,
            IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _options = options;
            _currentUser = currentUser;

            _httpClient = _httpClientFactory.CreateClient("datingapp");
        }

        public Task<TResponse?> SendDeleteAsync<TResponse, TRequest>(string url, TRequest? model, bool isAnonymous = false)
        {
            throw new NotImplementedException();
        }

        public async Task<TResponse?> SendGetAsync<TResponse>(string url, bool isAnonymous = false)
        {
            try
            {
                var fullUrl = $"/api/{url}";

                _logger.LogInformation($"Sending POST request to {_options.BaseUrl}{fullUrl}.");

                if (await _currentUser.IsLoggedInAsync())
                {
                    SetAuthHeader(await _currentUser.GetTokenAsync());
                }

                var response = await _httpClient.GetAsync(fullUrl);

                var jsonResponse = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var responseModel = JsonConvert.DeserializeObject<TResponse>(jsonResponse);
                    _logger.LogInformation($"Reply POST {_options.BaseUrl}{fullUrl} - {jsonResponse}.");

                    return responseModel;
                }
                else
                {
                    _logger.LogWarning($"Bad reply for {fullUrl}. Details: {jsonResponse}");
                }

                return default(TResponse);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"Gateway server returns exception with HTTP code: {ex.StatusCode} and message {ex.Message}.");

#if DEBUG
                _logger.LogDebug($"Exception details: {ex.Message}{Environment.NewLine}{ex.Data}");
#endif

                return default(TResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unknown exception has been occured: {ex.Message}.");

#if DEBUG
                _logger.LogDebug($"Exception details: {ex.Message}{Environment.NewLine}{ex.Data}");
#endif

                return default(TResponse);
            }
        }

        public async Task<TResponse?> SendPostAsync<TResponse, TRequest>(string url, TRequest? model, bool isAnonymous = false) 
        {
            try
            {
                var fullUrl = $"/api/{url}";

                if (await _currentUser.IsLoggedInAsync())
                {
                    SetAuthHeader(await _currentUser.GetTokenAsync());
                }

                string content;
                HttpResponseMessage response;

                if (model != null)
                {
                    content = JsonConvert.SerializeObject(model);
                    var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

                    _logger.LogInformation($"Sending POST request to {_options.BaseUrl}{fullUrl} with body {content}.");

                    response = await _httpClient.PostAsync(fullUrl, stringContent);
                }
                else
                {
                    _logger.LogInformation($"Sending POST request to {_options.BaseUrl}{fullUrl}.");

                    response = await _httpClient.PostAsync(fullUrl, null);
                }

                var jsonResponse = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var responseModel = JsonConvert.DeserializeObject<TResponse>(jsonResponse);
                    _logger.LogInformation($"Reply POST {_options.BaseUrl}{fullUrl} - {jsonResponse}.");

                    return responseModel;
                }
                else
                {
                    _logger.LogWarning($"Bad reply for {fullUrl}. Details: {jsonResponse}");
                }

                return default(TResponse);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"Gateway server returns exception with HTTP code: {ex.StatusCode} and message {ex.Message}.");

#if DEBUG
                _logger.LogDebug($"Exception details: {ex.Message}{Environment.NewLine}{ex.Data}");
#endif

                return default(TResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unknown exception has been occured: {ex.Message}.");

#if DEBUG
                _logger.LogDebug($"Exception details: {ex.Message}{Environment.NewLine}{ex.Data}");
#endif

                return default(TResponse);
            }
        }

        public async Task<TResponse?> SendPostAsync<TResponse>(string url, bool isAnonymous = false)
        {
            try
            {
                var fullUrl = $"/api/{url}";

                if (await _currentUser.IsLoggedInAsync())
                {
                    SetAuthHeader(await _currentUser.GetTokenAsync());
                }

                _logger.LogInformation($"Sending POST request to {_options.BaseUrl}{fullUrl}.");

                var response = await _httpClient.PostAsync(fullUrl, null);

                var jsonResponse = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var responseModel = JsonConvert.DeserializeObject<TResponse>(jsonResponse);
                    _logger.LogInformation($"Reply POST {_options.BaseUrl}{fullUrl} - {jsonResponse}.");

                    return responseModel;
                }
                else
                {
                    _logger.LogWarning($"Bad reply for {fullUrl}. Details: {jsonResponse}");
                }

                return default(TResponse);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError($"Gateway server returns exception with HTTP code: {ex.StatusCode} and message {ex.Message}.");

#if DEBUG
                _logger.LogDebug($"Exception details: {ex.Message}{Environment.NewLine}{ex.Data}");
#endif

                return default(TResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unknown exception has been occured: {ex.Message}.");

#if DEBUG
                _logger.LogDebug($"Exception details: {ex.Message}{Environment.NewLine}{ex.Data}");
#endif

                return default(TResponse);
            }
        }

        private void SetAuthHeader(string? value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", value);
            }
        }
    }
}
