using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;

namespace Fathy.Common.Storage;

public class BlobRepository : IBlobRepository
{
    private readonly string _blobContainerName;
    private readonly BlobServiceClient _blobServiceClient;
    
    public BlobRepository(BlobServiceClient blobServiceClient, string blobContainerName)
    {
        _blobContainerName = blobContainerName;
        _blobServiceClient = blobServiceClient;
    }

    public async Task<bool> DeleteBlobAsync(string blobName)
    {
        var blobClient = _blobServiceClient.GetBlobContainerClient(_blobContainerName).GetBlobClient(blobName);
        return await blobClient.DeleteIfExistsAsync();
    }

    public async Task<BlobDownloadInfo?> DownloadBlobAsync(string blobName)
    {
        var blobClient = _blobServiceClient.GetBlobContainerClient(_blobContainerName).GetBlobClient(blobName);
        return (await blobClient.ExistsAsync()).Value ? (await blobClient.DownloadAsync()).Value : null;
    }
    
    public async Task<string> UploadBlobAsync(string blobName, IFormFile file)
    {
        var blobClient = _blobServiceClient.GetBlobContainerClient(_blobContainerName).GetBlobClient(blobName);
        
        var blobContentInfo
            = await blobClient.UploadAsync(file.OpenReadStream(), new BlobHttpHeaders
            {
                ContentType = file.ContentType
            });
        
        return blobContentInfo is not null && !blobContentInfo.GetRawResponse().IsError
            ? blobClient.Uri.AbsoluteUri
            : string.Empty;
    }
}