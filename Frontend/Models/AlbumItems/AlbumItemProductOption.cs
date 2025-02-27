namespace Front.Models.AlbumItems;

public class AlbumItemProductOption(
    string name,
    List<string> options
)
    : IAlbumItem
{
    public string Name { get; } = name;
    public List<string> Options { get; } = options;
}