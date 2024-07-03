namespace si730ebu202124343.API.Maintenance.Domain.Model.Commands;

public record CreateMaintenanceActivityCommand(string ProductSerialNumber, string Summary, string Description, int Result);

