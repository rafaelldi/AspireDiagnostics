using DiagnosticsSidecar;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<DiagnosticsClientService>();
builder.Services.AddHostedService<ConnectorService>();

var app = builder.Build();

app.MapPost("/dump",
    (DiagnosticsClientService service, CancellationToken ct) => service.CollectMemoryDumpAsync(ct));

app.Run();