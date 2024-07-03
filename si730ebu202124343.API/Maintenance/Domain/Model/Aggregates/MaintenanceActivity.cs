using si730ebu202124343.API.Maintenance.Domain.Model.Commands;
using si730ebu202124343.API.Maintenance.Domain.Model.ValueObjects;

namespace si730ebu202124343.API.Maintenance.Domain.Model.Aggregates;

public class MaintenanceActivity
{
    public int Id { get; set; }
    public string ProductSerialNumber { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public ActivityResult Result { get; set; }

    public MaintenanceActivity()
    {
        
    }

    public MaintenanceActivity(CreateMaintenanceActivityCommand command)
    {
        this.ProductSerialNumber = command.ProductSerialNumber;
        this.Summary = command.Summary;
        this.Description = command.Description;
        this.Result = (ActivityResult)command.Result;
    }
}