using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace Shared.Models;

[Table("products")]
public class Product
{
    [Key, Column("id")] public int Id { get; init; }
    [Column("name")] public required string Name { get; init; }
    [Column("description")] public string? Description { get; init; }
    [Column("available")] public bool Available { get; init; }
    [Column("image_url")] public required string ImageUrl { get; init; }

    [Column("options")] public int[] Options { get; init; } = [];

    [NotMapped] public string? ImageBase64 { get; set; }
}