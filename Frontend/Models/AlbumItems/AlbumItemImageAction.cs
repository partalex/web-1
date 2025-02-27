namespace Front.Models.AlbumItems;

public class AlbumItemImageAction(
    string actionText,
    string imageUrl,
    string actionLink,
    string description = ""
)
    : AlbumItemImage(imageUrl)
{
    public string ActionLink { get; } = actionLink;
    public string ActionText { get; } = actionText;
    public string Description { get; } = description;
}