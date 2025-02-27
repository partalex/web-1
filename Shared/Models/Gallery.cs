using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

[Table("gallery")]
public class Gallery
{
    [Key, Column("id")] public int Id { get; init; }
    [Column("name")] public required string Name { get; init; }
    [Column("description")] public required string Description { get; init; }
    [Column("image_url")] public required string ImageUrl { get; init; }
    [Column("album_path")] public required string AlbumPath { get; init; }

    [NotMapped] public string? ImageBase64 { get; set; }
    [NotMapped] public IEnumerable<string> ImageUrls { get; set; } = [];
}