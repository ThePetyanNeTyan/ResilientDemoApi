using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http.Resilience;
using Microsoft.Extensions.Resilience;
using ResilientDemoApi.HttpClients;
using ResilientDemoApi.Options;
using ResilientDemoApi.Services;
using System.Runtime;
using System.Text;

namespace ResilientDemoApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<GeneralOpt>(builder.Configuration.GetSection("GeneralOpt"));

            // Add services to the container.

            builder.Services.AddControllers();

            //полли
            builder.Services.AddHttpClient<IMyExternalApiClient, MyExternalApiClient>()
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