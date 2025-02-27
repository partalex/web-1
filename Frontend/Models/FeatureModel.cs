namespace Frontend.Models;

public class FeatureModel(
    string title,
    string content,
    string actionLink = "",
    string actionText = ""
)
{
    public string Title { get; } = title;
    public string Content { get; } = content;
    public string ActionLink { get; } = actionLink;
    public string ActionText { get; } = actionText;
}