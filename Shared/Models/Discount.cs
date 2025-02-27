using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

[Table("discounts")]
public class Discount
{
    [Key, Column("id")] public int Id { get; init; }
    [Column("name")] public required string Name { get; init; }
    [Column("description")] public required string Description { get; init; }
    [Column("discount_type")] public DiscountType DiscountType { get; init; }
    [Column("value")] public decimal Value { get; init; }
    [Column("start_date")] public DateTime StartDate { get; init; }
    [Column("end_date")] public DateTime EndDate { get; init; }
    [Column("active")] public bool Active { get; init; }
    [Column("amount")] public decimal? Amount { get; init; }
    [Column("percent")] public decimal? Percent { get; init; }

    public decimal CalculateFinalPrice(decimal basePrice, int quantity)
    {
        return DiscountType switch
        {
            DiscountType.Fixed => basePrice * quantity - (Amount ?? 0),
            DiscountType.Percentage => basePrice * quantity * (1 - (Percent ?? 0) / 100),
            _ => basePrice * quantity
        };
    }
}

public enum DiscountType
{
    Fixed,
    Percentage
}