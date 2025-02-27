using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

[Table("manufacturers")]
public class Manufacturer
{
    [Key, Column("id")] public int Id { get; init; }
    [Column("name")] public required string Name { get; init; }
    [Column("description")] public required string Description { get; init; }
    [Column("website")] public required string Website { get; init; }

    [Column("is_partner")] public bool IsPartner { get; init; }

    [Column("image_url")] public required string ImageUrl { get; init; }

    [Column("activities")] public int[] Activities { get; init; }


    [NotMapped] public string? ImageBase64 { get; set; }
}