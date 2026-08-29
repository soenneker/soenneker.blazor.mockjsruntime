using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.JSInterop;
using Soenneker.Blazor.MockJsRuntime.Abstract;

namespace Soenneker.Blazor.MockJsRuntime.Registrars;

/// <summary>
/// A simple threadsafe version of IJSRuntime for testing with Blazor
/// </summary>
public static class MockJsRuntimeRegistrar
{
    /// <summary>
    /// Adds one scoped <see cref="MockJsRuntime"/> instance as <see cref="MockJsRuntime"/>, <see cref="IMockJsRuntime"/>, and <see cref="IJSRuntime"/>.
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddMockJsRuntimeAsScoped(this IServiceCollection services)
    {
        services.TryAddScoped<MockJsRuntime>();
        services.TryAddScoped<IMockJsRuntime>(provider => provider.GetRequiredService<MockJsRuntime>());
        services.TryAddScoped<IJSRuntime>(provider => provider.GetRequiredService<MockJsRuntime>());

        return services;
    }
}
