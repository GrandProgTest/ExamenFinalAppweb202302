using si730ebu202124343.API.Maintenance.Domain.Model.Commands;
using si730ebu202124343.API.Maintenance.Interfaces.REST.Resources;

namespace si730ebu202124343.API.Maintenance.Interfaces.REST.Transform;

public class CreateMaintenanceActivityCommandFromResourceAssembler
{
    public static CreateMaintenanceActivityCommand ToCommandFromResource(CreateMaintenanceActivityResource resource)
    {
        return new CreateMaintenanceActivityCommand(resource.ProductSerialNumber, resource.Summary, resource.Description, resource.Result);
    }
}