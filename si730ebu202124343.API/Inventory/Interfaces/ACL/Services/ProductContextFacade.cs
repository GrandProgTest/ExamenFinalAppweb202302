using si730ebu202124343.API.Inventory.Domain.Model.Queries;
using si730ebu202124343.API.Inventory.Domain.Services;

namespace si730ebu202124343.API.Inventory.Interfaces.ACL.Services;

public class ProductContextFacade(
    IProductQueryService productQueryService,
    IProductCommandService productCommandService) : IProductContextFacade
{
    public async Task<int> FetchProductIdBySerialNumber(string serialNumber)
    {
        var getProductBySerialNumberQuery = new GetProductBySerialNumberQuery(serialNumber);
        var result = await productQueryService.Handle(getProductBySerialNumberQuery);
        return result?.Id ?? 0;    }
}