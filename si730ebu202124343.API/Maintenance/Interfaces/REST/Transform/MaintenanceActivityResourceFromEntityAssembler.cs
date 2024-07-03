using si730ebu202124343.API.Maintenance.Domain.Model.Aggregates;
using si730ebu202124343.API.Maintenance.Interfaces.REST.Resources;

namespace si730ebu202124343.API.Maintenance.Interfaces.REST.Transform;

public class MaintenanceActivityResourceFromEntityAssembler
{
    public static MaintenanceActivityResource ToResourceFromEntity(MaintenanceActivity entity)
    {
        return new MaintenanceActivityResource(entity.Id, entity.ProductSerialNumber, entity.Summary, entity.Description, (int)entity.Result);
    }
}