using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

public class NavCategories
{
    public int Id { get; init; }
    public required string Name { get; init; }
}