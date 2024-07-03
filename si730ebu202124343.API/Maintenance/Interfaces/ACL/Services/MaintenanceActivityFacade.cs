using si730ebu202124343.API.Maintenance.Domain.Model.Queries;
using si730ebu202124343.API.Maintenance.Domain.Services;

namespace si730ebu202124343.API.Maintenance.Interfaces.ACL.Services;

public class MaintenanceActivityFacade(IMaintenanceActivityQueryService maintenanceActivityQueryService,
    IMaintenanceActivityCommandService maintenanceActivityCommandService) : IMaintenanceActivityContextFacade
{
    public async Task<int> FetchMaintenanceActivityResultBySerialNumber(string serialNumber)
    {
        var getMaintenanceActivityResultBySerialNumber = new GetMaintenanceActivityResultBySerialNumber(serialNumber);
        var result = await maintenanceActivityQueryService.Handle(getMaintenanceActivityResultBySerialNumber);
        return result;
    }
}