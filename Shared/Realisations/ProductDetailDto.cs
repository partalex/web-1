namespace Shared.Realisations;

public class ProductDetailDto
{
    public required string Name { get; init; }
    public required string ImageUrl { get; init; }
    public required string Description { get; init; }
    public List<ProductOptionDto> Options { get; init; } = [];
    public string? ImageBase64 { get; set; }
}