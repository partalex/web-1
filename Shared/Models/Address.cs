using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

[Table("addresses")]
public class Address
{
    [Key, Column("id")] public int Id { get; init; }
    [Column("street")] public required string Street { get; init; }
    [Column("house_number")] public required string HouseNumber { get; init; }
    [Column("zip_code")] public required string ZipCode { get; init; }
    [Column("city")] public required string City { get; init; }
    [Column("country")] public required string Country { get; init; }
    [NotMapped] public string FullAddress => $"{Street} {HouseNumber}, {ZipCode} {City}, {Country}";
}