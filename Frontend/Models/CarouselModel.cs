namespace Frontend.Models;

public class CarouselModel(
    string imageUrl,
    string tittle = "",
    string description = "",
    string actionText = "",
    string actionLink = ""
)
{
    public string ImageUrl { get; } = imageUrl;
    public string Tittle { get; } = tittle;
    public string? ImageBase64 { get; set; }
    public string ActionText { get; } = actionText;
    public string ActionLink { get; } = actionLink;
    public string Description { get; } = description;
}