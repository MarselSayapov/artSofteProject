using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Contexts;

public sealed class UserDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();

    public UserDbContext() => Database.EnsureCreatedAsync();
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            "Host=localhost;Port=5432;Database=ProfileServiceDatabase;Username=postgres;Password=qwasecd12qw");
    }
}