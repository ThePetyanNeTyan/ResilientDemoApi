using Microsoft.AspNetCore.Mvc.Filters;
using Polly;
using System;
using System.Threading.Tasks;

public class RetryAttribute : Attribute, IAsyncActionFilter
{
    private readonly int _retryCount;

    public RetryAttribute(int retryCount = 3)
    {
        _retryCount = retryCount;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var retryPolicy = Policy
            .Handle<Exception>()
            .WaitAndRetryAsync(_retryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

        await retryPolicy.ExecuteAsync(async () => { await next(); });
    }
}