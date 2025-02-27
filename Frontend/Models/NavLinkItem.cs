namespace Frontend.Models;

public enum AuthState
{
    NotMatter,
    Authenticated,
    Unauthenticated
}

public class NavLinkItem(string url, string name, AuthState authState = AuthState.NotMatter)
{
    public string Name { get; } = name;
    public string Url { get; } = url;
    public AuthState AuthState { get; set; } = authState;
}

public class NavDropdownItem(string url, string name, IEnumerable<NavLinkItem> items)
    : NavLinkItem(url, name)
{
    public IEnumerable<NavLinkItem> Items { get; } = items;
}