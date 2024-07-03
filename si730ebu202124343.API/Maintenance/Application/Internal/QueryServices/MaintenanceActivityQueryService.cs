using si730ebu202124343.API.Inventory.Domain.Model.Aggregates;
using si730ebu202124343.API.Maintenance.Domain.Model.Aggregates;
using si730ebu202124343.API.Maintenance.Domain.Model.Queries;
using si730ebu202124343.API.Maintenance.Domain.Repositories;
using si730ebu202124343.API.Maintenance.Domain.Services;

namespace si730ebu202124343.API.Maintenance.Application.Internal.QueryServices;

public class MaintenanceActivityQueryService(IMaintenanceActivityRepository maintenanceActivityRepository)
: IMaintenanceActivityQueryService
{
    public async Task<MaintenanceActivity?> Handle(GetMaintenanceActivityByIdQuery query)
    {
        return await maintenanceActivityRepository.FindByIdAsync(query.MaintenanceActivityId);
    }
    
    public async Task<int> Handle(GetMaintenanceActivityResultBySerialNumber query)
    {
        var maintenanceActivity = await maintenanceActivityRepository.GetMaintenanceActivityResultBySerialNumber(query.SerialNumber);
        return maintenanceActivity;
    }
}