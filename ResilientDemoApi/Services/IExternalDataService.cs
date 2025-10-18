namespace ResilientDemoApi.Services
{
    public interface IExternalDataService
    {
        Task<string> GetDataFromExternalApiAsync();
        Task<string> GetTimeOutFromExternalApiAsync();
        Task<string> GetFromCbApiAsync();
    }
}