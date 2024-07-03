namespace si730ebu202124343.API.Maintenance.Interfaces.REST.Resources;

public record MaintenanceActivityResource(int Id, string ProductSerialNumber, string Summary, string Description, int Result);

