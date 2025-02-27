namespace Frontend.Models;

public class HeadingModel(
    string title,
    string description,
    bool showButtons = false,
    string primaryActionText = "",
    string primaryActionLink = "",
    string secondaryActionText = "",
    string secondaryActionLink = "")
{
    public string Title { get; } = title;
    public string Description { get; } = description;
    public string PrimaryActionText { get; } = primaryActionText;
    public string PrimaryActionLink { get; } = primaryActionLink;
    public string SecondaryActionText { get; } = secondaryActionText;
    public string SecondaryActionLink { get; } = secondaryActionLink;

    public bool ShowButtons { get; } = showButtons;
}