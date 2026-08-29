using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.JSInterop;

namespace Soenneker.Blazor.MockJsRuntime.Registrars;

/// <summary>
/// A simple threadsafe version of IJSRuntime for testing with Blazor
/// </summary>
public static class MockJsRuntimeRegistrar
{
    /// <summary>
    /// Adds <see cref="MockJsRuntime"/> as a scoped service. <para/> as <see cref="IJSRuntime"/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddMockJsRuntimeAsScoped(this IServiceCollection services)
    {
        services.TryAddSingleton<IJSRuntime, MockJsRuntime>();

        return services;
    }
}
