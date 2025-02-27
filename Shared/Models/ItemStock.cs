using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

[Table("item_stocks")]
public class ItemStock
{
    [Column("item_id")] public int ItemId { get; init; }
    public Item? Item { get; init; }

    [Column("stock_id")] public int StockId { get; init; }
    public Stock? Stock { get; init; }

    [Column("quantity")] public int Quantity { get; init; }
    [Column("updated_at")] public DateTime UpdatedAt { get; init; }
}