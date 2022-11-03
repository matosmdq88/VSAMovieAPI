using VSAMovie.WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices(builder);

var app = builder.Build();

app.ConfigureApplication();

app.Run();