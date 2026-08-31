[![](https://img.shields.io/nuget/v/soenneker.launchdarkly.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.launchdarkly.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.launchdarkly.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.launchdarkly.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.launchdarkly.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.launchdarkly.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.launchdarkly.openapiclientutil/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.launchdarkly.openapiclientutil/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.LaunchDarkly.OpenApiClientUtil

Create and reuse an authenticated LaunchDarkly generated client over the shared HTTP transport.

## Install

```bash
dotnet add package Soenneker.LaunchDarkly.OpenApiClientUtil
```

## Configure and register

```json
{ "LaunchDarkly": { "ApiKey": "<access token>" } }
```

```csharp
services.AddLaunchDarklyOpenApiClientUtilAsScoped();
```

The scoped utility deliberately keeps `ILaunchDarklyOpenApiHttpClient` singleton. Disposing a scope releases its generated-client wrapper without tearing down the long-lived transport used by later scopes. Use the singleton registration when the wrapper should also live for the application lifetime.

The HTTP provider defaults to `https://app.launchdarkly.com/api/v2` and sends the token directly in `Authorization`. It also supports `ClientBaseUrl`, `AuthHeaderName`, and `AuthHeaderValueTemplate` under `LaunchDarkly`.

```csharp
LaunchDarklyOpenApiClient client = await clientUtil.Get(cancellationToken);
CallerIdentityRep? identity = await client.Api.V2.CallerIdentity.GetAsync(
    cancellationToken: cancellationToken);
```

Authentication is supplied by the underlying provider, so Kiota does not add a second header. Let the service container dispose the utility and provider.
