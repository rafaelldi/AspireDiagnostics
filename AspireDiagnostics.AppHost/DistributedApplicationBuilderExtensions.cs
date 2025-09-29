namespace AspireDiagnostics.AppHost;

internal static class DistributedApplicationBuilderExtensions
{
    internal static IResourceBuilder<ProjectResource> AddProjectWithDiagnostics<TProject>(
        this IDistributedApplicationBuilder builder, [ResourceName] string name)
        where TProject : IProjectMetadata, new()
    {
        var dateTimeString = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        var diagnosticsPortPath = Path.Combine(Path.GetTempPath(), $"{dateTimeString}.sock");

        var sidecar = builder
            .AddProject<Projects.DiagnosticsSidecar>($"{name}-sidecar")
            .WithHttpCommand("/dump", "Collect Memory Dump")
            .WithEnvironment("MY_DIAGNOSTICS_PORT", diagnosticsPortPath);

        var project=  builder
            .AddProject<TProject>(name)
            .WithEnvironment("DOTNET_DiagnosticPorts", $"{diagnosticsPortPath},nosuspend")
            .WaitFor(sidecar);
        
        sidecar.WithParentRelationship(project);
        
        return project;
    }
}