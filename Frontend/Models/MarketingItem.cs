namespace Frontend.Models;

public class MarketingItem(string title, string description, string imageUrl, string descriptionSecondary = "")
{
    public string Title { get; } = title;
    public string Description { get; } = description;
    public string DescriptionSecondary { get; set; } = descriptionSecondary;
    public string ImageUrl { get; } = imageUrl;
    public string? ImageBase64 { get; set; }
}
