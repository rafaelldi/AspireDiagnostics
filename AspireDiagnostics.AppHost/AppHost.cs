using AspireDiagnostics.AppHost;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProjectWithDiagnostics<Projects.AspireDiagnostics_ApiService>("apiservice")
    .WithHttpHealthCheck("/health");

builder.Build().Run();