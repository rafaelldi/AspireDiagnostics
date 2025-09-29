var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.AspireDiagnostics_ApiService>("apiservice")
    .WithHttpHealthCheck("/health");

builder.Build().Run();