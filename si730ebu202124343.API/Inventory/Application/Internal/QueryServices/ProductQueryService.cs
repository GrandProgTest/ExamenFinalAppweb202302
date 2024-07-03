using si730ebu202124343.API.Inventory.Domain.Model.Aggregates;
using si730ebu202124343.API.Inventory.Domain.Model.Queries;
using si730ebu202124343.API.Inventory.Domain.Repositories;
using si730ebu202124343.API.Inventory.Domain.Services;

namespace si730ebu202124343.API.Inventory.Application.Internal.QueryServices;

public class ProductQueryService(IProductRepository productRepository)
:IProductQueryService
{
    public async Task<Product?> Handle(GetProductByIdQuery query)
    {
        return await productRepository.FindByIdAsync(query.ProductId);
    }
    
    public async Task<Product?> Handle(GetProductBySerialNumberQuery query)
    {
        return await productRepository.FindBySerialNumberAsync(query.SerialNumber);
    }
}