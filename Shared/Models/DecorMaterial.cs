using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

[Table("decor_materials")]
public class DecorMaterial
{
    [Key, Column("id")] public int Id { get; init; }

    [Column("name")] public required string Name { get; init; }

    [Column("description")] public  string? Description { get; init; }
}