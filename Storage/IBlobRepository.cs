using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;

namespace Fathy.Common.Storage;

public interface IBlobRepository
{
    Task<bool> DeleteBlobAsync(string blobName);
    Task<BlobDownloadInfo?> DownloadBlobAsync(string blobName);
    Task<string> UploadBlobAsync(string blobName, IFormFile file);
}