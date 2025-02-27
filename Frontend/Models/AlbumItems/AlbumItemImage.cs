namespace Front.Models.AlbumItems;

public abstract class AlbumItemImage(string imageUrl, string imagePrefix = "")
    : IAlbumItem
{
    public string ImageUrl { get; } = $"{imagePrefix}{imageUrl}";
    public string? ImageBase64 { get; set; }
}