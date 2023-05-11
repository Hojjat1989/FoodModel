using Food.Api;
using Food.Api.Containers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connectionStrings = builder.Configuration.GetSection(nameof(ConnectionStrings));
builder.Services.Register(connectionStrings);

var app = builder.Build();

app.MapControllers();

app.Run();