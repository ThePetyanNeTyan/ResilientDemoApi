using ResilientDemoApi.HttpClients;

namespace ResilientDemoApi.Services
{
    public class ExternalDataService : IExternalDataService
    {
        private readonly IMyExternalApiClient _externalApiClient;

        public ExternalDataService(IMyExternalApiClient externalApiClient)
        {
            _externalApiClient = externalApiClient;
        }

        public async Task<string> GetDataFromExternalApiAsync()
        {
            return await _externalApiClient.GetExternalDataAsync();
        }

        public async Task<string> GetFromCbApiAsync()
        {
            return await _externalApiClient.GetUsdRateAsync(DateTimeOffset.Now);
        }

        public async Task<string> GetTimeOutFromExternalApiAsync()
        {
            return await _externalApiClient.GetTimeOutAsync();
        }

        public async Task<string> GetTimeOutFromExternalApiAsync(DateTimeOffset date)
        {
            return await _externalApiClient.GetTimeOutAsync();
        }
    }
}