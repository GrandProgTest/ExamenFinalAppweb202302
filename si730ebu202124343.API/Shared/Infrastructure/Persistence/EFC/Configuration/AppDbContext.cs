using si730ebu202124343.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using si730ebu202124343.API.Inventory.Domain.Model.Aggregates;
using si730ebu202124343.API.Maintenance.Domain.Model.Aggregates;

namespace si730ebu202124343.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Product>().HasKey(p => p.Id);
        builder.Entity<Product>().Property(p => p.Id).ValueGeneratedOnAdd();
        builder.Entity<Product>().Property(p => p.Brand).IsRequired();
        builder.Entity<Product>().Property(p => p.Model).IsRequired();
        builder.Entity<Product>().Property(p => p.Status).IsRequired();
        
        builder.Entity<MaintenanceActivity>().HasKey(p => p.Id);
        builder.Entity<MaintenanceActivity>().Property(p => p.Id).ValueGeneratedOnAdd();
        builder.Entity<MaintenanceActivity>().Property(p => p.ProductSerialNumber).IsRequired();
        builder.Entity<MaintenanceActivity>().Property(p => p.Summary).IsRequired();
        builder.Entity<MaintenanceActivity>().Property(p => p.Description).IsRequired();
        builder.Entity<MaintenanceActivity>().Property(p => p.Result).IsRequired();


        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }

}