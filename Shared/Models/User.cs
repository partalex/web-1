using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models;

[Table("users")]
public class User
{
    [Key] [Column("id")] public int Id { get; init; }

    [Column("username")] public required string Username { get; init; }

    [Column("password")] public required string Password { get; init; }
    [Column("first_name")] public required string FirstName { get; init; }
    [Column("middle_name")] public string? MiddleName { get; init; }

    [Column("last_name")] public required string LastName { get; init; }

    [Column("number")] public string? Number { get; init; }
    [Column("email")] public string? Email { get; init; }
    [Column("created_at")] public DateTime CreatedAt { get; init; }
    [Column("last_update")] public DateTime LastUpdate { get; init; }
    [Column("blocked")] public bool Blocked { get; init; }
    [Column("role")] public Role Role { get; init; }

    // [Column("address_id")] public int AddressId { get; init; }
    // public Address? Address { get; init; }

    [Column("image_url")] public required string ImageUrl { get; init; }
    [NotMapped] public string? ImageBase64 { get; set; }
    [NotMapped] public string? FullName => $"{FirstName} {MiddleName} {LastName}";
}

public enum Role
{
    Sudo,
    Basic,
    Worker,
    Manager,
    Admin,
    Warehouseman
}