using DTO;

namespace Frontend.Services
{
    public class TestService(HttpClient httpClient)
    {
        private HttpClient _httpClient = httpClient;

        public async Task<Message> Get()
        {
            var respond = await _httpClient.GetAsync("Test");
            respond.EnsureSuccessStatusCode();
            var data = await respond.Content.ReadFromJsonAsync<Message>();
            return data ?? throw new Exception("Message not found");
        }
    }
}