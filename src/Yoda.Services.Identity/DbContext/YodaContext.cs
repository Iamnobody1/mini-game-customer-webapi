using Microsoft.EntityFrameworkCore;
using Yoda.Services.Identity.Entities;

namespace Yoda.Services.Identity.Data;

public class YodaContext : DbContext
{
    public YodaContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<CustomerEntity> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerEntity>(e =>
        {
            e.ToTable("Customer");
        });
    }
}
