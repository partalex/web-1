using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StorageController(
    ILogger<StorageController> logger,
    ApplicationDbContext context,
    ServerStorageService storageService
) : ControllerBase
{
    private const string Container = "container";

    [HttpGet("getFileUrl/{fileName}")]
    public async Task<IActionResult> GetFileBase64(string fileName)
    {
        var decodedFileName = Uri.UnescapeDataString(fileName);
        var url = await storageService.GetFileUrl(Container, decodedFileName);
        return Ok(url);
    }

    [HttpGet("list")]
    public async Task<IActionResult> ListFiles()
    {
        var files = await storageService
            .ListFilesAsync(Container);
        return Ok(files);
    }

    [HttpGet("list/{directory}")]
    public async Task<IActionResult> ListDirectoryFiles(string directory)
    {
        var path = Uri.UnescapeDataString(directory);
        var files = await storageService
            .ListDirectoryFiles(Container, path);
        return Ok(files);
    }


    [HttpGet("search/{searchString}")]
    public async Task<IActionResult> SearchFiles(string searchString)
    {
        logger.LogInformation("Searching for files with name containing {SearchString}", searchString);
        var files = await storageService
            .SearchFilesAsync(Container, searchString);
        return Ok(files);
    }
}