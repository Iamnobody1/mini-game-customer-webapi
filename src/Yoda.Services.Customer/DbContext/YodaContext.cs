using Microsoft.EntityFrameworkCore;
using Yoda.Services.Customer.Entities;

namespace Yoda.Services.Customer.Data;

public class YodaContext : DbContext
{
    public YodaContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<OrderDetailEntity> OrderDetails { get; set; }
    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<DistrictEntity> Districts { get; set; }
    public DbSet<SubDistrictEntity> SubDistricts { get; set; }
    public DbSet<PostalCodeEntity> PostalCodes { get; set; }
    public DbSet<ProvinceEntity> Provinces { get; set; }
    public DbSet<CountryEntity> Countries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AddressEntity>(e =>
        {
            e.ToTable("Address");
            e.Property(p => p.Id).ValueGeneratedOnAdd();
            e.HasOne(p => p.Customer).WithOne(b => b.Address);
        });

        modelBuilder.Entity<CountryEntity>(e =>
        {
            e.ToTable("Country");
            e.Property(p => p.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<CustomerEntity>(e =>
        {
            e.ToTable("Customer");
            e.Property(p => p.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<DistrictEntity>(e =>
       {
           e.ToTable("District");
           e.Property(p => p.Id).ValueGeneratedOnAdd();
           e.HasOne(p => p.Province).WithMany(b => b.Districts);
       });

        modelBuilder.Entity<OrderEntity>(e =>
        {
            e.ToTable("Order");
            e.Property(p => p.Id).ValueGeneratedOnAdd();
            e.HasOne(p => p.Customer).WithMany(b => b.Orders);
        });

        modelBuilder.Entity<OrderDetailEntity>(e =>
        {
            e.ToTable("OrderDetail");
            e.Property(p => p.Id).ValueGeneratedOnAdd();
            e.HasOne(p => p.Product).WithMany(b => b.OrderDetails);
            e.HasOne(p => p.Order).WithMany(b => b.OrderDetails);
        });

        modelBuilder.Entity<PostalCodeEntity>(e =>
        {
            e.ToTable("PostalCode");
            e.Property(p => p.Id).ValueGeneratedOnAdd();
            e.HasOne(p => p.District).WithMany(b => b.postalCodes);
        });

        modelBuilder.Entity<ProductEntity>(e =>
        {
            e.ToTable("Product");
            e.Property(p => p.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<ProvinceEntity>(e =>
        {
            e.ToTable("Province");
            e.Property(p => p.Id).ValueGeneratedOnAdd();
            e.HasOne(p => p.Country).WithMany(b => b.Provinces);
        });

        modelBuilder.Entity<SubDistrictEntity>(e =>
        {
            e.ToTable("SubDistrict");
            e.Property(p => p.Id).ValueGeneratedOnAdd();
            e.HasOne(p => p.District).WithMany(b => b.SubDistricts);
        });
    }
}
