using Azure.Core.Pipeline;
using Azure.Storage.Blobs;
using Microsoft.Extensions.DependencyInjection;

namespace Fathy.Storage;

public static class DependencyInjection
{
    public static void AddStorageService(this IServiceCollection services, string connectionString, string blobContainerName)
    {
        services.AddSingleton<IBlobRepository, BlobRepository>(
            _ => new BlobRepository(new BlobServiceClient(connectionString, new BlobClientOptions
            {
                Transport = new HttpClientTransport(new HttpClient { Timeout = Timeout.InfiniteTimeSpan }),
                Retry = { NetworkTimeout = Timeout.InfiniteTimeSpan }
            }), blobContainerName)
        );
    }
}