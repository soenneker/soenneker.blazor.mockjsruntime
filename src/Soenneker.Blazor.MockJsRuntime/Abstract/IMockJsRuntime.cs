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
    void SetupMockResult<T>(string identifier, T result);
}
