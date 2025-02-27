using Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace API;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    // public DbSet<Address> Address { get; set; }
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Manufacturer> Manufacturers { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<ItemStock> ItemStocks { get; set; }
    public DbSet<Faq> Faqs { get; set; }
    public DbSet<Gallery> Gallery { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductOption> ProductOptions { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Filter> Filters { get; set; }
    public DbSet<ItemTag> ItemTags { get; set; }
    public DbSet<Decor> Decors { get; set; }

    public DbSet<DecorPurpose> DecorPurposes { get; set; }
    public DbSet<DecorMaterial> DecorMaterials { get; set; }
    public DbSet<DecorColor> DecorColors { get; set; }
    public DbSet<DecorReflection> DecorReflections { get; set; }
    public DbSet<DecorPattern> DecorPatterns { get; set; }
    public DbSet<ManufacturerActivity> ManufacturerActivities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure the relationship between User and Address
        // modelBuilder.Entity<User>()
        // .HasOne(u => u.Address)
        // .WithMany()
        // .HasForeignKey(u => u.AddressId);

        // Configure the uniqueness of the Username
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();

        // Configure the relationship between Stock and Address
        // modelBuilder.Entity<Stock>()
        // .HasOne(s => s.Address)
        // .WithMany()
        // .HasForeignKey(s => s.AddressId);

        // Configure the relationship between ItemStock and Item
        modelBuilder.Entity<ItemStock>()
            .HasOne(ps => ps.Item)
            .WithMany()
            .HasForeignKey(ps => ps.ItemId);

        // Configure the relationship between ItemStock and Stock
        modelBuilder.Entity<ItemStock>()
            .HasOne(ps => ps.Stock)
            .WithMany()
            .HasForeignKey(ps => ps.StockId);

        // Configure the composite key for ItemStock
        modelBuilder.Entity<ItemStock>()
            .HasKey(ps => new { ItemId = ps.ItemId, ps.StockId });

        // Configure the relationship between Faq and User
        modelBuilder.Entity<Faq>()
            .HasOne(f => f.User)
            .WithMany()
            .HasForeignKey(f => f.UserId);

        // Configure the composite key for ItemTags
        modelBuilder.Entity<ItemTag>()
            .HasKey(it => new { it.ItemId, TagId = it.TagId });

        // Configure the relationship between ItemTags and Item
        modelBuilder.Entity<ItemTag>()
            .HasOne(it => it.Item)
            .WithMany()
            .HasForeignKey(it => it.ItemId);

        // Configure the relationship between ItemTags and Tag
        modelBuilder.Entity<ItemTag>()
            .HasOne(it => it.Tag)
            .WithMany()
            .HasForeignKey(it => it.TagId);

        // Add an index on the ItemTags column
        modelBuilder.Entity<ItemTag>()
            .HasIndex(it => it.ItemId);

        // Configure the relationship between Tag and Filter
        modelBuilder.Entity<Tag>()
            .HasOne(t => t.Filter)
            .WithMany()
            .HasForeignKey(t => t.FilterId);

        // Configure options for Product
        modelBuilder.Entity<Product>()
            .Property(p => p.Options)
            .HasColumnType("jsonb")
            .HasColumnType("integer[]");

        // Configure the relationship between Decor and Manufacturer
        modelBuilder.Entity<Decor>()
            .HasOne(d => d.Manufacturer)
            .WithMany()
            .HasForeignKey(d => d.ManufacturerId);

        // Configure the Decor to use the DecorFilters
        modelBuilder.Entity<Decor>()
            .Property(d => d.Materials)
            .HasColumnType("integer[]");

        modelBuilder.Entity<Decor>()
            .Property(d => d.Purposes)
            .HasColumnType("integer[]");

        modelBuilder.Entity<Decor>()
            .Property(d => d.Colors)
            .HasColumnType("integer[]");

        modelBuilder.Entity<Decor>()
            .Property(d => d.Reflections)
            .HasColumnType("integer[]");

        modelBuilder.Entity<Decor>()
            .Property(d => d.Patterns)
            .HasColumnType("integer[]");

        // Configure the Manufacturer to use the ManufacturerActivities
        modelBuilder.Entity<Manufacturer>()
            .Property(m => m.Activities)
            .HasColumnType("integer[]");

        modelBuilder.Entity<Filter>().HasData(
            new Filter
            {
                Id = (int)FilterType.OneOfTrueFalse, StringFalseListTrue = false, Description = "OneOfTrueFalse"
            },
            new Filter
            {
                Id = (int)FilterType.MultipleOfMany, StringFalseListTrue = true, Description = "MultipleOfMany"
            },
            new Filter { Id = (int)FilterType.TextSearch, StringFalseListTrue = false, Description = "TextSearch" },
            new Filter { Id = (int)FilterType.Image, StringFalseListTrue = false, Description = "Image" },
            new Filter { Id = (int)FilterType.NoFiltering, StringFalseListTrue = false, Description = "NoFiltering" },
            new Filter { Id = (int)FilterType.OneOfMany, StringFalseListTrue = true, Description = "OneOfMany" },
            new Filter
            {
                Id = (int)FilterType.NumberInRange, StringFalseListTrue = false, Description = "NumberInRange"
            },
            new Filter
            {
                Id = (int)FilterType.UniqueMultipleOfMany, StringFalseListTrue = false,
                Description = "UniqueMultipleOfMany"
            }
        );
    }
}