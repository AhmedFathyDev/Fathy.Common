using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;

namespace Fathy.Storage;

public interface IBlobRepository
{
    Task<string> UploadBlobAsync(string blobName, IFormFile file);
    Task<BlobDownloadInfo?> DownloadBlobAsync(string blobName);
    Task<bool> DeleteBlobAsync(string blobName);
}