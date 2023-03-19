using Dapr.Client;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDaprStarter(options =>
    {
        options.AppIdSuffix = String.Empty;
    });
}

builder.Services.AddDaprClient();

var app = builder.Build();

app.MapGet("/hello", async (DaprClient client) =>
{
    var result = await client.InvokeMethodAsync<string>(
        HttpMethod.Get, "ServiceB", "hello");

    return $"Call ServiceB: {result}";
});

app.Run();
