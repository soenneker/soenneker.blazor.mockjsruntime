using Microsoft.JSInterop;

namespace Soenneker.Blazor.MockJsRuntime.Abstract;

/// <summary>
/// A simple thread-safe version of IJSRuntime for testing with Blazor
/// </summary>
public interface IMockJsRuntime : IJSRuntime
{
    /// <summary>
    /// Sets up a mocked result for a specific identifier.
    /// </summary>
    /// <typeparam name="T">Type of value handled by the Mock JavaScript Runtime.</typeparam>
    /// <param name="identifier">Identifier of the target value.</param>
    /// <param name="result">Result accumulated by the operation.</param>
    void SetupMockResult<T>(string identifier, T result);
}
