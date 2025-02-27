using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

[Table("filters")]
public class Filter
{
    [Key, Column("id")] public int Id { get; init; }
    [Column("string_false_list_true")] public bool StringFalseListTrue { get; init; }
    [Column("descriptions")] public required string Description { get; init; }

    public static char Delimiter { get; } = ',';
}

public enum FilterType
{
    OneOfTrueFalse = 1,
    MultipleOfMany = 2,
    TextSearch = 3,
    Image = 4,
    NoFiltering = 5,
    OneOfMany = 6,
    NumberInRange = 7,
    UniqueMultipleOfMany = 8,
}