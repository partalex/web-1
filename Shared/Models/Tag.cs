using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

[Table("tags")]
public class Tag
{
    [Key, Column("id")] public int Id { get; init; }
    [Column("name")] public required string Name { get; init; }
    [Column("filter_id")] public int FilterId { get; init; }
    public Filter? Filter { get; init; }
}

public enum TagType
{
    Name = 1,
    Manufacturer,
    Price,
    Available,
    Texture,
    ImageUrl,
    Description,
    Type,
    CountryOfOrigin
}