namespace Microsoft.Extensions.ServiceDiscovery;

public static class ServiceDiscoveryExtensions
{
    public static async ValueTask<string?> ResolveEndPointUrlAsync(this ServiceEndpointResolver resolver, string serviceName, CancellationToken cancellationToken = default)
    {
        var scheme = ExtractScheme(serviceName);
        var endpoints = await resolver.GetEndpointsAsync(serviceName, cancellationToken);
        if (endpoints.Endpoints.Count > 0)
        {
            return endpoints.Endpoints[0].ToString();
        }
        return null;
    }

    private static string? ExtractScheme(string serviceName)
    {
        if (Uri.TryCreate(serviceName, UriKind.Absolute, out var uri))
        {
            return uri.Scheme;
        }
        return null;
    }
}
