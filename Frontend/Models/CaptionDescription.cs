namespace Frontend.Models;

public class CaptionDescription(string caption, string description)
{
    public string Caption { get; } = caption;
    public string Description { get; } = description;
}