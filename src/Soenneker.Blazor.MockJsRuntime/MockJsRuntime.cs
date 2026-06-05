using System.Collections.Concurrent;
using System.Threading.Tasks;
using System;
using System.Threading;
using Soenneker.Blazor.MockJsRuntime.Abstract;

namespace Soenneker.Blazor.MockJsRuntime;

/// <summary>
/// A simple thread-safe version of IJSRuntime for testing with Blazor
/// </summary>
public sealed class MockJsRuntime : IMockJsRuntime
{
    private readonly ConcurrentDictionary<string, object> _mockedResults = new();

    public void SetupMockResult<T>(string identifier, T result)
    {
        _mockedResults[identifier] = result!;
    }

    /// <summary>
    /// Executes the invoke async operation.
    /// </summary>
    /// <typeparam name="TValue">The TValue type.</typeparam>
    /// <param name="identifier">The identifier.</param>
    /// <param name="args">The args.</param>
    /// <returns>A task containing the result of the operation.</returns>
    public ValueTask<TValue> InvokeAsync<TValue>(string identifier, object?[]? args)
    {
        if (_mockedResults.TryGetValue(identifier, out object? result))
            return ValueTask.FromResult((TValue) result);

        throw new InvalidOperationException($"No mock setup for identifier: {identifier}");
    }

    /// <summary>
    /// Executes the invoke async operation.
    /// </summary>
    /// <typeparam name="TValue">The TValue type.</typeparam>
    /// <param name="identifier">The identifier.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <param name="args">The args.</param>
    /// <returns>A task containing the result of the operation.</returns>
    public ValueTask<TValue> InvokeAsync<TValue>(string identifier, CancellationToken cancellationToken, object?[]? args)
    {
        if (cancellationToken.IsCancellationRequested)
            return ValueTask.FromCanceled<TValue>(cancellationToken);

        if (_mockedResults.TryGetValue(identifier, out object? result))
            return ValueTask.FromResult((TValue) result);

        throw new InvalidOperationException($"No mock setup for identifier: {identifier}");
    }
}
