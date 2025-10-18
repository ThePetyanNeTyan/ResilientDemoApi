using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ResilientDemoApi.Options;
using System.Globalization;
using System.Text;

namespace ResilientDemoApi.HttpClients
{
    public class MyExternalApiClient : IMyExternalApiClient
    {
        private readonly HttpClient _httpClient;

        public MyExternalApiClient(HttpClient httpClient, IOptions<GeneralOpt> options)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(options.Value.CBUri);
        }

        public async Task<string> GetUsdRateAsync(DateTimeOffset date)
        {
            var formattedDate = date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            var response = await _httpClient.GetAsync(
                $"/scripts/XML_daily.asp?date_req={formattedDate}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
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