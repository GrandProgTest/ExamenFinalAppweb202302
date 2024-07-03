namespace si730ebu202124343.API.Inventory.Domain.Model.Commands;

public record CreateProductCommand(string Brand, string Model, string SerialNumber, string StatusDescription);