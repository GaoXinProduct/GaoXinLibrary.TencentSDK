using Microsoft.Extensions.Logging;

namespace GaoXinLibrary.TencentSDK.Tests;

internal sealed class TestLogger<T> : ILogger<T>
{
    private readonly List<LogEntry> _entries = [];

    public IReadOnlyList<LogEntry> Entries => _entries;

    public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

    public bool IsEnabled(LogLevel logLevel) => true;

    public void Log<TState>(
        LogLevel logLevel,
        EventId eventId,
        TState state,
        Exception? exception,
        Func<TState, Exception?, string> formatter)
    {
        _entries.Add(new LogEntry(logLevel, formatter(state, exception), exception));
    }
}

internal sealed record LogEntry(LogLevel Level, string Message, Exception? Exception);
