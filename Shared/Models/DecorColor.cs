using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

[Table("decor_colors")]
public class DecorColor
{
    [Column("id")] public int Id { get; init; }
    [Column("name")] public required string Name { get; init; }
    [Column("description")] public string? Description { get; init; }
}