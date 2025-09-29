namespace AspireDiagnostics.AppHost;

internal static class DistributedApplicationBuilderExtensions
{
    internal static IResourceBuilder<ProjectResource> AddProjectWithDiagnostics<TProject>(
        this IDistributedApplicationBuilder builder, [ResourceName] string name)
        where TProject : IProjectMetadata, new()
    {
        builder
            .AddProject<Projects.DiagnosticsSidecar>($"{name}-sidecar");

        return builder
            .AddProject<TProject>(name, _ => { });
    }
}