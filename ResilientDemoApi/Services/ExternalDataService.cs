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

        public async Task<string> GetTimeOutFromExternalApiAsync()
        {
            return await _externalApiClient.GetTimeOutAsync();
        }
    }
}