using Microsoft.Diagnostics.NETCore.Client;

namespace DiagnosticsSidecar;

internal class ConnectorService(DiagnosticsClientService service) : BackgroundService, IAsyncDisposable
{
    private DiagnosticsClientConnector? _connector;

    protected override async Task ExecuteAsync(CancellationToken ct)
    {
        var diagnosticsPort = Environment.GetEnvironmentVariable("MY_DIAGNOSTICS_PORT");
        if (diagnosticsPort == null) return;
        _connector = await DiagnosticsClientConnector.FromDiagnosticPort(diagnosticsPort, ct);
        service.InitializeWithClient(_connector.Instance);
    }

    public async ValueTask DisposeAsync()
    {
        if (_connector != null) await _connector.DisposeAsync();
    }
}