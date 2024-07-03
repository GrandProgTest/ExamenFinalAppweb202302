using si730ebu202124343.API.Inventory.Domain.Model.Aggregates;
using si730ebu202124343.API.Inventory.Domain.Model.Queries;

namespace si730ebu202124343.API.Inventory.Domain.Services;

public interface IProductQueryService
{
    Task<Product?> Handle(GetProductByIdQuery query);

    Task<Product?> Handle(GetProductBySerialNumberQuery query);
}