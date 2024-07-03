using si730ebu202124343.API.Maintenance.Domain.Model.Aggregates;
using si730ebu202124343.API.Maintenance.Domain.Model.Queries;

namespace si730ebu202124343.API.Maintenance.Domain.Services;

public interface IMaintenanceActivityQueryService
{
    Task<MaintenanceActivity?> Handle(GetMaintenanceActivityByIdQuery query);
}