namespace ResilientDemoApi.Models
{
    public class ExternalDataResponse
    {
        public string Data { get; set; }
        public DateTimeOffset RequestedAt { get; set; } = DateTimeOffset.Now;
        public bool IsSuccess { get; set; } = true;
    }
}