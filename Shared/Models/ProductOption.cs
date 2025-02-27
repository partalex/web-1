using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

[Table("product_options")]
public class ProductOption
{
    [Key, Column("id")] public int Id { get; init; }
    [Column("name")] public required string Name { get; init; }
    [Column("options")] public required string Options { get; init; }
    [Column("description")] public string? Description { get; init; }
}
