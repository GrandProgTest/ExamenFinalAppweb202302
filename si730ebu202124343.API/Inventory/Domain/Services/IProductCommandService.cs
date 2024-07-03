using si730ebu202124343.API.Inventory.Domain.Model.Aggregates;
using si730ebu202124343.API.Inventory.Domain.Model.Commands;

namespace si730ebu202124343.API.Inventory.Domain.Services;

public interface IProductCommandService
{
    Task<Product?> Handle(CreateProductCommand command);
}