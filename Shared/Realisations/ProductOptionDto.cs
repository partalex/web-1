namespace Shared.Realisations;

public class ProductOptionDto
{
    public required string Name { get; init; }
    public required List<string> Options { get; init; }
    public static readonly string Delimiter = " | ";
}