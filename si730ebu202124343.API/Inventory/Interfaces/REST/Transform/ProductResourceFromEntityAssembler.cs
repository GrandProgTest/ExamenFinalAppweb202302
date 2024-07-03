using si730ebu202124343.API.Inventory.Domain.Model.Aggregates;
using si730ebu202124343.API.Inventory.Interfaces.REST.Resources;

namespace si730ebu202124343.API.Inventory.Interfaces.REST.Transform;

public class ProductResourceFromEntityAssembler
{
    public static ProductResource ToResourceFromEntity(Product entity)
    {
        return new ProductResource(entity.Id, entity.Brand, entity.Model, entity.SerialNumber, entity.StatusDescription);
    }
}