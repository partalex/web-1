using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

[Table("socials")]
public class Social
{
    [Key, Column("id")]  public int Id { get; init; }
    [Column("url")] public required string Url { get; init; }
    [Column("social_type")] public SocialType SocialType { get; init; }
}

public enum SocialType
{
    Facebook,
    Instagram,
    X,
    LinkedIn,
    Pinterest,
    TikTok,
    YouTube
}