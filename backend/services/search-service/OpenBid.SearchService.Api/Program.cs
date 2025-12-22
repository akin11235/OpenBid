using MassTransit;
using OpenBid.SearchService.Api.Services;
using Polly;
using Polly.Extensions.Http;
using System.Net;

namespace OpenBid.SearchService.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddHttpClient<AuctionSvcHttpClient>().AddPolicyHandler(GetPolicy());

            builder.Services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.ConfigureEndpoints(context);
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Lifetime.ApplicationStarted.Register(async () =>
            {
                try
                {
                    await Data.DbInitializer.InitDb(app);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while initializing the database: {ex.Message}");
                }
            });
           
            app.Run();

            static IAsyncPolicy<HttpResponseMessage> GetPolicy()
                => HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == HttpStatusCode.NotFound)
                .WaitAndRetryForeverAsync(_ => TimeSpan.FromSeconds(3));
        }
    }
}
