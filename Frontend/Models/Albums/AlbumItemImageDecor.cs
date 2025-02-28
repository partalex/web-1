namespace Frontend.Models.Albums;

public class AlbumItemImageDecor(
    string imageUrl,
    string name
)
    : AlbumItemImage(imageUrl, "Decors/Thumbnails/")
{
    public string Name { get; } = name;
}