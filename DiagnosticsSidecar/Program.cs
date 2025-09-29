using DiagnosticsSidecar;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<DiagnosticsClientService>();
builder.Services.AddHostedService<ConnectorService>();

var app = builder.Build();

app.MapPost("/dump", () => { });

app.Run();