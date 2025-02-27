using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

[Table("item_tags")]
public class ItemTag
{
    [Column("item_id")] public int ItemId { get; init; }
    public Item? Item { get; init; }

    [Column("tag_id")] public int TagId { get; init; }
    public Tag? Tag { get; init; }

    [Column("value")] public required string Value { get; init; }
}