using MongoDB.Driver;
using MongoDB.Entities;
using OpenBid.SearchService.Api.Models;

namespace OpenBid.SearchService.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();
            try
            {
                await Data.DbInitializer.InitDb(app);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while initializing the database: {ex.Message}");
            }


            app.Run();
        }
    }
}
