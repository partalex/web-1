using Azure.Storage.Blobs;

namespace API.Services.Storage;

public class AzureStorageService(string connectionString)
    : StorageService(connectionString)
{
    private readonly BlobServiceClient _client = new(connectionString);

    public override Task<string> GetFileUrl(string containerName, string blobName)
    {
        var containerClient = _client.GetBlobContainerClient(containerName);
        var blobClient = containerClient.GetBlobClient(blobName);
        return Task.FromResult(blobClient.Uri.ToString());
    }

    public override async Task<List<string>> ListFilesAsync(string containerName)
    {
        var containerClient = _client.GetBlobContainerClient(containerName);
        var items = new List<string>();
        await foreach (var blobItem in containerClient.GetBlobsAsync()) items.Add(blobItem.Name);
        return items;
    }

    public override async Task<List<string>> ListDirectoryFiles(string containerName, string directory)
    {
        var containerClient = _client.GetBlobContainerClient(containerName);
        var items = new List<string>();
        await foreach (var blobHierarchyItem in containerClient.GetBlobsByHierarchyAsync(prefix: directory))
        {
            if (blobHierarchyItem.IsBlob && blobHierarchyItem.Blob.Name != directory)
                items.Add(blobHierarchyItem.Blob.Name);
        }

        return items;
    }

    public override async Task<List<string>> SearchFilesAsync(string containerName, string searchString)
    {
        var containerClient = _client.GetBlobContainerClient(containerName);
        var items = new List<string>();
        await foreach (var blobItem in containerClient.GetBlobsAsync())
            if (blobItem.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) &&
                !blobItem.Name.EndsWith("/"))
                items.Add(blobItem.Name);
        return items;
    }
}