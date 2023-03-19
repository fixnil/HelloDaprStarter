var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDaprStarter(options =>
{
    options.AppIdSuffix = String.Empty;
});

var app = builder.Build();

app.MapGet("/hello", () => "\"Hello Dapr Starter.\"");

Console.WriteLine("");

app.Run();
