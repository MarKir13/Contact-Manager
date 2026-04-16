using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<User> Users { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Subcategory> Subcategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Contact>().HasIndex(c => c.Email).IsUnique();

        // database seeding
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = Guid.NewGuid(), Name = "Służbowy"},
            new Category { Id = Guid.NewGuid(), Name = "Prywatny"},
            new Category { Id = Guid.NewGuid(), Name = "Inny"}
        );

        modelBuilder.Entity<Subcategory>().HasData(
            new Subcategory { Id = Guid.NewGuid(), Name = "Szef" },
            new Subcategory { Id = Guid.NewGuid(), Name = "Klient" },
            new Subcategory { Id = Guid.NewGuid(), Name = "Współpracownik" },
            new Subcategory { Id = Guid.NewGuid(), Name = "Kadry" },
            new Subcategory { Id = Guid.NewGuid(), Name = "Księgowość" }
        );

        

    }
}