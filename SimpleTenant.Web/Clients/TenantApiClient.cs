using System.Net.Http.Headers;

namespace SimpleTenant.Web.Clients
{
    /// <inheritdoc/>
    public class TenantApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly string _apiUrlName = "SimpleTenant.API.Url";
        private readonly string _apiUrlSuffix = "SimpleTenant.API.TenantSuffix";

        public TenantApiClient(IConfiguration config)
        {
            _config = config;
            var apiUrl = _config[_apiUrlName];
            if(string.IsNullOrEmpty(apiUrl))
                throw new ArgumentException("SimpleTenant.API.Url is empty.");
            _httpClient = new HttpClient { BaseAddress = new Uri(apiUrl) };
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <inheritdoc/>
        public async Task<T> GetAsync<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);
            return await response.Content.ReadFromJsonAsync<T>();
        }

        /// <inheritdoc/>
        public async Task<T1> PostAsync<T1, T2>(string url, T2 content)
        {
            var response = await _httpClient.PostAsJsonAsync(url, content, new CancellationToken());
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadFromJsonAsync<T1>();
            return responseData;
        }

        /// <inheritdoc/>
        public async Task<T1> PutAsync<T1, T2>(string url, T2 content)
        {
            var response = await _httpClient.PutAsJsonAsync<T2>(url, content, new CancellationToken());
            response.EnsureSuccessStatusCode();
            var responseData = await response.Content.ReadFromJsonAsync<T1>();
            return responseData;
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteAsync(string url)
        {
            var response = await _httpClient.DeleteAsync(url);
            return response.IsSuccessStatusCode;
        }
    }
}