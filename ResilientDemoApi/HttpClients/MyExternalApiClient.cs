namespace ResilientDemoApi.HttpClients
{
    public class MyExternalApiClient : IMyExternalApiClient
    {
        private readonly HttpClient _httpClient;

        public MyExternalApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetExternalDataAsync()
        {
            var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/404");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetTimeOutAsync()
        {
            var response = await _httpClient.GetAsync(" http://httpstat.us/200?sleep=15000");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}