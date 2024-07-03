using si730ebu202124343.API.Inventory.Domain.Model.Aggregates;
using si730ebu202124343.API.Shared.Domain.Repositories;

namespace si730ebu202124343.API.Inventory.Domain.Repositories;

public interface IProductRepository : IBaseRepository<Product>
{
    bool ExistsBySerialNumber(string serialNumber);
    
    Task<Product?> FindBySerialNumberAsync(string serialNumber);
}