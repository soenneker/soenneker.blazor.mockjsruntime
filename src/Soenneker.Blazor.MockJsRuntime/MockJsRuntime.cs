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
    /// Invokes async.
    /// </summary>
    /// <typeparam name="TValue">Type of value stored or returned by the operation.</typeparam>
    /// <param name="identifier">Identifier of the target value.</param>
    /// <param name="args">Command-line arguments passed to the application.</param>
    /// <returns>A task whose result is the value returned by invoke Async.</returns>
    public ValueTask<TValue> InvokeAsync<TValue>(string identifier, object?[]? args)
    {
        if (_mockedResults.TryGetValue(identifier, out object? result))
            return ValueTask.FromResult((TValue) result);

        throw new InvalidOperationException($"No mock setup for identifier: {identifier}");
    }

    /// <summary>
    /// Invokes async.
    /// </summary>
    /// <typeparam name="TValue">Type of value stored or returned by the operation.</typeparam>
    /// <param name="identifier">Identifier of the target value.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <param name="args">Command-line arguments passed to the application.</param>
    /// <returns>A task whose result is the value returned by invoke Async.</returns>
    public ValueTask<TValue> InvokeAsync<TValue>(string identifier, CancellationToken cancellationToken, object?[]? args)
    {
        if (cancellationToken.IsCancellationRequested)
            return ValueTask.FromCanceled<TValue>(cancellationToken);

        if (_mockedResults.TryGetValue(identifier, out object? result))
            return ValueTask.FromResult((TValue) result);

        throw new InvalidOperationException($"No mock setup for identifier: {identifier}");
    }
}
