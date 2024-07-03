using Microsoft.EntityFrameworkCore;
using si730ebu202124343.API.Inventory.Domain.Model.Aggregates;
using si730ebu202124343.API.Inventory.Domain.Repositories;
using si730ebu202124343.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using si730ebu202124343.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace si730ebu202124343.API.Inventory.Infrastructure.Persistence.EFC.Repositories;

public class ProductRepository(AppDbContext context) : BaseRepository<Product>(context), IProductRepository
{
    public bool ExistsBySerialNumber(string serialNumber)
    {
        return context.Set<Product>().Any(p => p.SerialNumber.Equals(serialNumber));
    }
    
    public async Task<Product?> FindBySerialNumberAsync(string serialNumber)
    {
        return await context.Set<Product>().FirstOrDefaultAsync(p => p.SerialNumber.Equals(serialNumber));
    }
    
}