using Microsoft.Diagnostics.NETCore.Client;

namespace DiagnosticsSidecar;

internal class DiagnosticsClientService
{
    private DiagnosticsClient? _client;

    internal void InitializeWithClient(DiagnosticsClient client)
    {
        _client = client;
    }

    internal async Task CollectMemoryDumpAsync(CancellationToken ct)
    {
        if (_client == null) return;
        await _client.WriteDumpAsync(DumpType.Normal, "/home/rival/Projects/dumps/my", false, ct);
    }
}