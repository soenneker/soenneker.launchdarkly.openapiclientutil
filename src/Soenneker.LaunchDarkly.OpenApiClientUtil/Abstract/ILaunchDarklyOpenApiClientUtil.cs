using Soenneker.LaunchDarkly.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.LaunchDarkly.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface ILaunchDarklyOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<LaunchDarklyOpenApiClient> Get(CancellationToken cancellationToken = default);
}
