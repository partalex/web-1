using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

[Table("services")]
public class Service
{
    [Key, Column("id")] public int Id { get; init; }
    [Column("name")] public required string Name { get; init; }
    [Column("description")] public required string Description { get; init; }
    [Column("price")] public decimal Price { get; init; }
    [Column("available")] public bool Available { get; init; }
    [Column("featured")] public bool Featured { get; init; }

    [Column("image_url_1")] public required string ImageUrl1 { get; init; }
    [Column("image_url_2")] public required string ImageUrl2 { get; init; }
    [Column("image_url_3")] public required string ImageUrl3 { get; init; }
}