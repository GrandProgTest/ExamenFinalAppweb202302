using si730ebu202124343.API.Inventory.Domain.Model.Aggregates;
using si730ebu202124343.API.Inventory.Domain.Model.Commands;
using si730ebu202124343.API.Inventory.Domain.Repositories;
using si730ebu202124343.API.Inventory.Domain.Services;
using si730ebu202124343.API.Shared.Domain.Repositories;

namespace si730ebu202124343.API.Inventory.Application.Internal.CommandServices;

public class ProductCommandService(IProductRepository productRepository, IUnitOfWork unitOfWork) : 
    IProductCommandService
{
    public async Task<Product?> Handle(CreateProductCommand command)
    {
        if(productRepository.ExistsBySerialNumber(command.SerialNumber))
            throw new Exception("Product with the same serial number already exists");

        if(command.StatusDescription != "OPERATIONAL" && command.StatusDescription != "UNOPERATIONAL")
            throw new Exception("Invalid StatusDescription. It must be either 'OPERATIONAL' or 'UNOPERATIONAL'");

        var product = new Product(command);
        try
        {
            await productRepository.AddAsync(product);
            await unitOfWork.CompleteAsync();
            return product;
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while saving the product", e);
            return null;
        }
    }
}