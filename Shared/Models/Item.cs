using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

[Table("items")]
public class Item
{
    [Key, Column("id")] public int Id { get; init; }
}