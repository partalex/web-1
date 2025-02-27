namespace Shared.Realisations;

public class ProductShortDto
{
    public required string Name { get; init; }
    public required string ImageUrl { get; init; }
    public required string Description { get; init; }
    public string? ImageBase64 { get; set; }
}