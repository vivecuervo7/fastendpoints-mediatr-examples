using Example_Mediator.Domain;
using Microsoft.EntityFrameworkCore;

namespace Example_Mediator.Infrastructure;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=file::memory:?cache=shared");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .Entity<User>()
            .HasData(
                new User
                {
                    Id = 1,
                    Name = "Alice",
                    Email = "alice@example.com"
                },
                new User
                {
                    Id = 2,
                    Name = "Bob",
                    Email = "bob@example.com"
                }
            );
    }
}
