// IProductContextFacade.cs

using si730ebu202124343.API.Inventory.Domain.Model.Commands;

namespace si730ebu202124343.API.Inventory.Interfaces.ACL;

public interface IProductContextFacade
{
    Task<int> FetchProductIdBySerialNumber(string serialNumber);
    Task UpdateProductStatusBySerialNumber(UpdateProductBySerialNumberCommand command);
}