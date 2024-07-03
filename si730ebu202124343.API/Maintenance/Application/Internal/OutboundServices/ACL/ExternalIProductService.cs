using si730ebu202124343.API.Inventory.Interfaces.ACL;
using si730ebu202124343.API.Maintenance.Domain.Model.ValueObjects;
using si730ebu202124343.API.Inventory.Domain.Model.Commands;

namespace si730ebu202124343.API.Maintenance.Application.Internal.OutboundServices.ACL;

public class ExternalIProductService(IProductContextFacade productContextFacade)
{
    public async Task<ProductId?> FetchProductIdBySerialNumber(string serialNumber)
    {
        var productId = await productContextFacade.FetchProductIdBySerialNumber(serialNumber);
        if(productId ==0) return await Task.FromResult<ProductId?>(null);
        return new ProductId(productId);
    }

    public async Task UpdateProductStatusBySerialNumber(UpdateProductBySerialNumberCommand command)
    {
        await productContextFacade.UpdateProductStatusBySerialNumber(command);
    }
}