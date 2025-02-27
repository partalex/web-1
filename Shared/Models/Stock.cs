using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

[Table("stocks")]
public class Stock
{
    [Key] [Column("id")] public int Id { get; init; }
    [Column("name")] public string? Name { get; set; }
    [Column("description")] public string? Description { get; init; }
    [Column("address_id")] public int AddressId { get; init; }
    public Address? Address { get; init; }
    [Column("opened_at")] public DateTime OpenedAt { get; init; }
    [Column("closed_at")] public DateTime? ClosedAt { get; init; }
    [Column("active")] public bool Active { get; init; }
}