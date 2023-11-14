using MedfarTest.Data.Configurations;
using MedfarTest.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedfarTest.Data;

public class MedfarTestDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    
    public DbSet<Lookup> Lookups { get; set; } = null!;
    
    public DbSet<IndividualMessage> IndividualMessages { get; set; } = null!;
    
    public DbSet<Contact> Contacts { get; set; } = null!;
    
    public MedfarTestDbContext()
    {
    }

    public MedfarTestDbContext(DbContextOptions<MedfarTestDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new UserConfigurations().Configure(modelBuilder.Entity<User>());
        new LookupConfiguration().Configure(modelBuilder.Entity<Lookup>());
        new IndividualMessageConfiguration().Configure(modelBuilder.Entity<IndividualMessage>());
        new ContactConfiguration().Configure(modelBuilder.Entity<Contact>());
    }
}