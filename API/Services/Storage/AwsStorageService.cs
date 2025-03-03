using Amazon.S3;
using Amazon.S3.Model;

namespace API.Services.Storage;

public class AwsStorageService : StorageService
{
    private readonly IAmazonS3 _client;

    public AwsStorageService(string accessKey, string secretKey, string region)
        : base(accessKey)
    {
        var config = new AmazonS3Config
        {
            RegionEndpoint = Amazon.RegionEndpoint.GetBySystemName(region)
        };
        _client = new AmazonS3Client(accessKey, secretKey, config);
    }

    public override async Task<string> GetFileUrl(string containerName, string blobName)
    {
        var request = new GetPreSignedUrlRequest
        {
            BucketName = containerName,
            Key = blobName,
            Expires = DateTime.UtcNow.AddHours(1)
        };
        var url = await _client.GetPreSignedURLAsync(request);
        return await Task.FromResult(url);
    }

    public override async Task<List<string>> ListFilesAsync(string containerName)
    {
        var request = new ListObjectsV2Request
        {
            BucketName = containerName
        };
        var response = await _client.ListObjectsV2Async(request);
        return response.S3Objects.Select(o => o.Key).ToList();
    }

    public override async Task<List<string>> ListDirectoryFiles(string containerName, string directory)
    {
        var request = new ListObjectsV2Request
        {
            BucketName = containerName,
            Prefix = directory
        };
        var response = await _client.ListObjectsV2Async(request);
        return response.S3Objects
            .Where(o => o.Key != directory)
            .Select(o => o.Key)
            .ToList();
    }

    public override async Task<List<string>> SearchFilesAsync(string containerName, string searchString)
    {
        var request = new ListObjectsV2Request
        {
            BucketName = containerName
        };
        var response = await _client.ListObjectsV2Async(request);
        return response.S3Objects
            .Where(o => o.Key.Contains(searchString, StringComparison.OrdinalIgnoreCase) && !o.Key.EndsWith("/"))
            .Select(o => o.Key)
            .ToList();
    }
}