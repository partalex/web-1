using Shared.Models;

namespace MudBlazorWebApp1.Services;

public class UserService(HttpClient httpClient)
    : ServiceApiGet<User>(httpClient, "api/User")
{
}