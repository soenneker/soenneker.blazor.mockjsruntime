using System.Collections.Concurrent;
using System.Threading.Tasks;
using System;
using System.Threading;
using Soenneker.Blazor.MockJsRuntime.Abstract;

namespace Soenneker.Blazor.MockJsRuntime;

/// <summary>
/// A simple threadsafe version of IJSRuntime for testing with Blazor
/// </summary>
public class MockJsRuntime : IMockJsRuntime
{
    private readonly ConcurrentDictionary<string, object> _mockedResults = new();

    /// <summary>
    /// Sets up a mocked result for a specific identifier.
    /// </summary>
    public void SetupMockResult<T>(string identifier, T result)
    {
        _mockedResults[identifier] = result!;
    }

    public ValueTask<TValue> InvokeAsync<TValue>(string identifier, object?[]? args)
    {
        if (_mockedResults.TryGetValue(identifier, out object? result))
            return ValueTask.FromResult((TValue) result);

        throw new InvalidOperationException($"No mock setup for identifier: {identifier}");
    }

    public ValueTask<TValue> InvokeAsync<TValue>(string identifier, CancellationToken cancellationToken, object?[]? args)
    {
        if (_mockedResults.TryGetValue(identifier, out object? result))
            return ValueTask.FromResult((TValue) result);

        throw new InvalidOperationException($"No mock setup for identifier: {identifier}");
    }
}