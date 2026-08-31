using Soenneker.LaunchDarkly.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.LaunchDarkly.OpenApiClientUtil.Abstract;

/// <summary>
/// Provides a lazily created LaunchDarkly generated client over the shared authenticated transport.
/// </summary>
public interface ILaunchDarklyOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<LaunchDarklyOpenApiClient> Get(CancellationToken cancellationToken = default);
}
