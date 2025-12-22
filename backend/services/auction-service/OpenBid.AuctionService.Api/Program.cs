using AuctionService.Api.Data;
using AuctionService.Entities.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Fix for CS1061: Ensure the required package is installed and the namespace is included
// Install the package `Microsoft.EntityFrameworkCore` and `Microsoft.EntityFrameworkCore.Relational` if not already installed
builder.Services.AddDbContext<AuctionDbContext>(opt =>
{ opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("AuctionService.Api")); 

});

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddMaps(typeof(Program).Assembly);
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

try
{
    DbInitializer.InitDb(app);
}
catch(Exception ex)
{
    Console.WriteLine($"An error occurred while initializing the database: {ex.Message}");
}

app.Run();