[![](https://img.shields.io/nuget/v/soenneker.blazor.mockjsruntime.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.mockjsruntime/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.mockjsruntime/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.mockjsruntime/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.blazor.mockjsruntime.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.mockjsruntime/)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Blazor.MockJsRuntime
### A simple threadsafe version of IJSRuntime for testing with Blazor

## Installation

```
dotnet add package Soenneker.Blazor.MockJsRuntime
```

## Usage
```csharp
services.AddMockJsRuntimeAsScoped()
```