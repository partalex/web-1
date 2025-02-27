namespace Frontend.Models;

// need a static class to hold the constants for the media limits
// like sm, md, lg, xl

public enum MediaLimit
{
    Small,
    Medium,
    Large,
    ExtraLarge,
    ExtraExtraLarge
}

public static class MediaLimitString
{
    public static string[] MediaLimitStrings { get; } =
    [
        "sm",
        "md",
        "lg",
        "xl",
        "xxl"
    ];
}