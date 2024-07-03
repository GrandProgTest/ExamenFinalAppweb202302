using si730ebu202124343.API.Inventory.Domain.Model.Aggregates;
using si730ebu202124343.API.Inventory.Domain.Model.Commands;
using si730ebu202124343.API.Inventory.Interfaces.REST.Resources;

namespace si730ebu202124343.API.Inventory.Interfaces.REST.Transform;

public class CreateProductCommandFromResourceAssembler
{
    public static CreateProductCommand ToCommandFromResource(CreateProductResource resource)
    {
        return new CreateProductCommand(resource.Brand, resource.Model, resource.SerialNumber, resource.StatusDescription);
    }
}