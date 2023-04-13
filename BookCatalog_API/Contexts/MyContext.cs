using Microsoft.EntityFrameworkCore;
using BookCatalog_API.Models;

namespace BookCatalog_API.Contexts;

public class MyContext : DbContext
{
    public MyContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountRole> AccountRoles { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Profile> Profiles { get; set; }

    // Fluent API
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Role>().HasData(
            new Role
            {
                Id = 1,
                Name = "Admin"
            },
            new Role
            {
                Id = 2,
                Name = "User"
            });

        // Membuat atribute menjadi unique
        modelBuilder.Entity<Profile>().HasIndex(u => new
        {
            u.Email
        }).IsUnique();

        modelBuilder.Entity<Book>().HasIndex(b => new
        {
            b.Isbn
        }).IsUnique();

        modelBuilder.Entity<Profile>()
            .HasOne(u => u.Account)
            .WithOne(a => a.Profile)
            .HasForeignKey<Account>(fk => fk.ProfileId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
