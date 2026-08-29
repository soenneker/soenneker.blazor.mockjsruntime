[![](https://img.shields.io/nuget/v/soenneker.blazor.mockjsruntime.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.mockjsruntime/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.mockjsruntime/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.mockjsruntime/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.blazor.mockjsruntime.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.mockjsruntime/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.mockjsruntime/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.mockjsruntime/actions/workflows/codeql.yml)

# Soenneker.Blazor.MockJsRuntime

A small, thread-safe `IJSRuntime` test double that returns results configured by JavaScript identifier.

It is intentionally strict and minimal: unconfigured identifiers throw, arguments are ignored, and invocations are not recorded. Use a fuller mocking library when tests need argument matching, call counts, or ordered verification.

## Installation

```bash
dotnet add package Soenneker.Blazor.MockJsRuntime
```

## Registration

```csharp
using Soenneker.Blazor.MockJsRuntime.Registrars;

services.AddMockJsRuntimeAsScoped();
```

The registrar creates one scoped `MockJsRuntime` and exposes that same instance as `MockJsRuntime`, `IMockJsRuntime`, and `IJSRuntime`. Register it only in test service collections; it does not execute JavaScript.

## Configure results

```csharp
using Microsoft.JSInterop;
using Soenneker.Blazor.MockJsRuntime.Abstract;

IMockJsRuntime mock = services.GetRequiredService<IMockJsRuntime>();
IJSRuntime js = services.GetRequiredService<IJSRuntime>();

mock.SetupMockResult("settings.getTheme", "dark");

string theme = await js.InvokeAsync<string>("settings.getTheme");
```

The generic result type must be assignable to the `TValue` requested by the code under test. A mismatched type produces an `InvalidCastException`. `null` can be configured for nullable/reference results:

```csharp
mock.SetupMockResult<string?>("storage.get", null);
string? value = await js.InvokeAsync<string?>("storage.get");
```

An identifier has one configured result; configuring it again replaces the previous value. Arguments do not affect lookup:

```csharp
mock.SetupMockResult("math.sum", 10);

int result = await js.InvokeAsync<int>("math.sum", 4, 6);
```

Calling an identifier without a setup throws `InvalidOperationException`. The cancellation-token overload returns a canceled `ValueTask` when its token is already canceled, before looking up a result.

Module imports are ordinary identifiers. When code calls `InvokeAsync<IJSObjectReference>("import", path)`, configure `"import"` with an `IJSObjectReference` test double whose own methods model the module calls.
