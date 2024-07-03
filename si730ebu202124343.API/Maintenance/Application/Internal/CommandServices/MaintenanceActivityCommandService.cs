using si730ebu202124343.API.Maintenance.Application.Internal.OutboundServices.ACL;
using si730ebu202124343.API.Maintenance.Domain.Model.Aggregates;
using si730ebu202124343.API.Maintenance.Domain.Model.Commands;
using si730ebu202124343.API.Maintenance.Domain.Repositories;
using si730ebu202124343.API.Maintenance.Domain.Services;
using si730ebu202124343.API.Shared.Domain.Repositories;
using si730ebu202124343.API.Inventory.Domain.Model.Commands;

namespace si730ebu202124343.API.Maintenance.Application.Internal.CommandServices;

public class MaintenanceActivityCommandService(IMaintenanceActivityRepository maintenanceActivityRepository, IUnitOfWork unitOfWork,
    ExternalIProductService externalIProductService)
    :IMaintenanceActivityCommandService
{
    public async Task<MaintenanceActivity?> Handle(CreateMaintenanceActivityCommand command)
    {
        if (await externalIProductService.FetchProductIdBySerialNumber(command.ProductSerialNumber) == null)
            throw new Exception("Product with the given serial number does not exist");
        if(command.Result != 1 && command.Result != 0)
            throw new Exception("Invalid Result. It must be either '0' or '1'");
        var maintenanceActivity = new MaintenanceActivity(command);
        try
        {
            await maintenanceActivityRepository.AddAsync(maintenanceActivity);
            await unitOfWork.CompleteAsync();

            // Update the product status based on the maintenance activity result
            var updateCommand = new UpdateProductBySerialNumberCommand(command.ProductSerialNumber, command.Result == 1 ? "OPERATIONAL" : "UNOPERATIONAL");
            await externalIProductService.UpdateProductStatusBySerialNumber(updateCommand);

            return maintenanceActivity;
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while saving the maintenance activity", e);
        }
    }
}