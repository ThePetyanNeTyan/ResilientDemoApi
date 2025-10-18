namespace ResilientDemoApi.HttpClients
{
    public interface IMyExternalApiClient
    {
        Task<string> GetExternalDataAsync();
        Task<string> GetTimeOutAsync();
        Task<string> GetUsdRateAsync(DateTimeOffset date);
    }
}