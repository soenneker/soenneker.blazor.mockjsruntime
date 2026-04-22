using Microsoft.JSInterop;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Blazor.MockJsRuntime.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class MockJsRuntimeTests : HostedUnitTest
{
    private readonly IJSRuntime _util;

    public MockJsRuntimeTests(Host host) : base(host)
    {
        _util = Resolve<IJSRuntime>(true);
    }

    [Test]
    public void Default()
    {

    }
}
