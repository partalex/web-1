using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

[Table("decors")]
public class Decor
{
    [Key, Column("id")] public int Id { get; init; }
    [Column("name")] public required string Name { get; init; }
    [Column("image_url")] public required string ImageUrl { get; init; }

    [Column("purposes")] public int[] Purposes { get; init; } = [];
    [Column("textures")] public int[] Textures { get; init; } = [];
    [Column("colors")] public int[] Colors { get; init; } = [];
    [Column("paterns")] public int[] Patterns { get; init; } = [];
    [Column("reflections")] public int[] Reflections { get; init; } = [];
    [Column("materials")] public int[] Materials { get; init; } = [];

    [Column("manufacturer_id")] public int ManufacturerId { get; init; }
    [ForeignKey("ManufacturerId")] public Manufacturer? Manufacturer { get; init; }
}