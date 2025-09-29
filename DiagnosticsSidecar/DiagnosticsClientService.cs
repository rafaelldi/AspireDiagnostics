using Microsoft.Diagnostics.NETCore.Client;

namespace DiagnosticsSidecar;

internal class DiagnosticsClientService
{
    private DiagnosticsClient? _client;

    internal void InitializeWithClient(DiagnosticsClient client)
    {
        _client = client;
    }
}