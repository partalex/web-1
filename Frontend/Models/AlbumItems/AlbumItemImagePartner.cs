namespace Front.Models.AlbumItems;

public class AlbumItemImagePartner(
    string imageUrl,
    string name,
    string description,
    string website
    // string activity
)
    : AlbumItemImage(imageUrl)
{
    public string Name { get; } = name;
    public string Description { get; } = description;

    public string Website { get; } = website;
    // public string Activity { get;  } = activity;
}