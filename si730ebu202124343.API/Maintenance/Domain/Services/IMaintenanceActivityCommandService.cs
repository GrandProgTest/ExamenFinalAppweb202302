using si730ebu202124343.API.Maintenance.Domain.Model.Aggregates;
using si730ebu202124343.API.Maintenance.Domain.Model.Commands;

namespace si730ebu202124343.API.Maintenance.Domain.Services;

public interface IMaintenanceActivityCommandService
{
    Task<MaintenanceActivity?> Handle(CreateMaintenanceActivityCommand command);
}