using Shared.Models;

namespace Frontend.Services;

public class UserService(HttpClient httpClient)
    : ServiceApiGet<User>(httpClient, "api/User")
{
}