using Food.Api;
using Food.Api.Containers;
using Food.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connectionStrings = builder.Configuration.GetSection(nameof(ConnectionStrings));
builder.Services.Register(connectionStrings);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<FoodDbContext>();
    dbContext.Database.EnsureCreated();
}

app.MapControllers();

app.Run();