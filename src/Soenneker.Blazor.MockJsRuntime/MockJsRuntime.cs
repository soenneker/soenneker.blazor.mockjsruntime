using System.Collections.Concurrent;
using System.Threading.Tasks;
using System;
using System.Threading;
using Soenneker.Blazor.MockJsRuntime.Abstract;

namespace Soenneker.Blazor.MockJsRuntime;

/// <inheritdoc cref="IMockJsRuntime"/>
public sealed class MockJsRuntime : IMockJsRuntime
{
    private static readonly object _nullResult = new();
    private readonly ConcurrentDictionary<string, object> _mockedResults = new();

    public void SetupMockResult<T>(string identifier, T result)
    {
        if (string.IsNullOrWhiteSpace(identifier))
            throw new ArgumentException("The JavaScript identifier cannot be null, empty, or whitespace.", nameof(identifier));

        _mockedResults[identifier] = result is null ? _nullResult : result;
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
            return ValueTask.FromResult(ReferenceEquals(result, _nullResult) ? default! : (TValue) result);

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
            return ValueTask.FromResult(ReferenceEquals(result, _nullResult) ? default! : (TValue) result);

        throw new InvalidOperationException($"No mock setup for identifier: {identifier}");
    }
}
