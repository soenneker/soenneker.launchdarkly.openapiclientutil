using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.LaunchDarkly.HttpClients.Abstract;
using Soenneker.LaunchDarkly.OpenApiClientUtil.Abstract;
using Soenneker.LaunchDarkly.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.LaunchDarkly.OpenApiClientUtil;

/// <inheritdoc cref="ILaunchDarklyOpenApiClientUtil" />
public sealed class LaunchDarklyOpenApiClientUtil : ILaunchDarklyOpenApiClientUtil
{
    private readonly AsyncSingleton<LaunchDarklyOpenApiClient> _client;

    public LaunchDarklyOpenApiClientUtil(ILaunchDarklyOpenApiHttpClient httpClientUtil)
    {
        _client = new AsyncSingleton<LaunchDarklyOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient);

            return new LaunchDarklyOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<LaunchDarklyOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
