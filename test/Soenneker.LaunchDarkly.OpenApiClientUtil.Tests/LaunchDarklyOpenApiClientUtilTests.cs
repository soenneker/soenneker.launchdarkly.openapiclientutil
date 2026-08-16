using Soenneker.LaunchDarkly.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.LaunchDarkly.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class LaunchDarklyOpenApiClientUtilTests : HostedUnitTest
{
    private readonly ILaunchDarklyOpenApiClientUtil _openapiclientutil;

    public LaunchDarklyOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<ILaunchDarklyOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
