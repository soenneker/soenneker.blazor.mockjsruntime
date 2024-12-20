using Microsoft.JSInterop;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Blazor.MockJsRuntime.Tests;

[Collection("Collection")]
public class MockJsRuntimeTests : FixturedUnitTest
{
    private readonly IJSRuntime _util;

    public MockJsRuntimeTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IJSRuntime>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
