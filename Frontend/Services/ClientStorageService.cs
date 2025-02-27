namespace Frontend.Services;

public class ClientStorageService(HttpClient httpClient)
    : ServiceApiBase(httpClient, "api/Storage")
{
    public async Task<string> GetFileBase64(string fileName)
    {
        var encodedFileName = Uri.EscapeDataString(fileName);
        var response = await HttpClient.GetAsync($"{Path}/getFileUrl/{encodedFileName}");
        response.EnsureSuccessStatusCode();
        var data = await response.Content.ReadAsStringAsync();
        return data;
    }

    public async Task<string> UploadFileAsync(MultipartFormDataContent content)
    {
        var response = await HttpClient.PostAsync($"{Path}/upload", content);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<Stream> DownloadFileAsync(string fileName)
    {
        var response = await HttpClient.GetAsync($"{Path}/download/{fileName}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStreamAsync();
    }

    public async Task<string> DeleteFileAsync(string fileName)
    {
        var response = await HttpClient.DeleteAsync($"{Path}/delete/{fileName}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<IEnumerable<string>> ListFilesAsync()
    {
        var response = await HttpClient.GetAsync($"{Path}/list");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IEnumerable<string>>() ?? new List<string>();
    }

    public async Task<IEnumerable<string>> ListDirectoryFilesAsync(string path)
    {
        var saferPath = Uri.EscapeDataString(path);
        var response = await HttpClient.GetAsync($"{Path}/list/{saferPath}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IEnumerable<string>>() ?? new List<string>();
    }

    public async Task<IEnumerable<string>> SearchFilesAsync(string searchString)
    {
        var response = await HttpClient.GetAsync($"{Path}/search/{searchString}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<IEnumerable<string>>() ?? new List<string>();
    }
}