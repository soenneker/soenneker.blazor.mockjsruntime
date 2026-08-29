[![](https://img.shields.io/nuget/v/soenneker.blazor.mockjsruntime.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.mockjsruntime/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.mockjsruntime/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.mockjsruntime/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.blazor.mockjsruntime.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.mockjsruntime/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.mockjsruntime/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.mockjsruntime/actions/workflows/codeql.yml)

# Soenneker.Blazor.MockJsRuntime

A simple thread-safe version of IJSRuntime for testing with Blazor.

## Install

```bash
dotnet add package Soenneker.Blazor.MockJsRuntime
```

## Quick start

```csharp
using Soenneker.Blazor.MockJsRuntime.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddMockJsRuntimeAsScoped();
```

Adds `MockJsRuntime` as a scoped service. as `IJSRuntime`.

## What you get

- `IMockJsRuntime` — A simple thread-safe version of IJSRuntime for testing with Blazor.
- `MockJsRuntimeRegistrar` — A simple threadsafe version of IJSRuntime for testing with Blazor.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `IMockJsRuntime.SetupMockResult(identifier, result)` | Sets up a mocked result for a specific identifier. | Returns no value; the requested change is complete when the method returns. |
| `MockJsRuntimeRegistrar.AddMockJsRuntimeAsScoped(services)` | Adds `MockJsRuntime` as a scoped service. as `IJSRuntime`. | The same service collection, so additional registrations can be chained. |
