using datalayer.Messages.Models;
using Microsoft.EntityFrameworkCore;

namespace datalayer.Messages.Contexts;

public sealed class MessageContext : DbContext
{
    public DbSet<MessageDal> Messages => Set<MessageDal>();
    public MessageContext() => Database.EnsureCreatedAsync();
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ChatServiceDataBase;Username=postgres;Password=qwasecd12qw");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MessageDal>()
            .HasKey(m => m.Id);
    }
}