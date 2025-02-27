using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

[Table("faqs")]
public class Faq
{
    [Key, Column("id")] public int Id { get; init; }

    [Column("tittle")] public required string Tittle { get; init; }
    [Column("question")] public required string Question { get; init; }
    [Column("answer")] public required string Answer { get; init; }
    [Column("created_at")] public DateTime CreatedAt { get; init; }
    [Column("updated_at")] public DateTime UpdatedAt { get; init; }
    [Column("available")] public bool Available { get; init; }

    [Column("user_id")] public int UserId { get; init; }
    public User? User { get; init; }
}