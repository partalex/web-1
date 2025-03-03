namespace API.Services.Storage;

public abstract class StorageService(string accessKey)
{
    public abstract Task<string> GetFileUrl(string containerName, string blobName);
    public abstract Task<List<string>> ListFilesAsync(string containerName);
    public abstract Task<List<string>> ListDirectoryFiles(string containerName, string directory);
    public abstract Task<List<string>> SearchFilesAsync(string containerName, string searchString);
}