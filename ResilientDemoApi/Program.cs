
using Polly;
using Polly.Extensions.Http;
using ResilientDemoApi.HttpClients;
using ResilientDemoApi.Services;

namespace ResilientDemoApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddHttpClient<IMyExternalApiClient, MyExternalApiClient>()
                .AddPolicyHandler(PollyPolicies.GetRetryPolicy())
                .AddPolicyHandler(PollyPolicies.GetTimeoutPolicy())
                .AddPolicyHandler(PollyPolicies.GetCircuitBreakerPolicy())
                .AddPolicyHandler(PollyPolicies.GetBulkheadPolicy());

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IExternalDataService, ExternalDataService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
