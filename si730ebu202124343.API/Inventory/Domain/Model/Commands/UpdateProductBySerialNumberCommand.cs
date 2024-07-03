namespace si730ebu202124343.API.Inventory.Domain.Model.Commands;

public record UpdateProductBySerialNumberCommand(string SerialNumber, string StatusDescription);