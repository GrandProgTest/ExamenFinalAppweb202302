namespace si730ebu202124343.API.Inventory.Interfaces.REST.Resources;

public record CreateProductResource(string Brand, string Model, string SerialNumber, string StatusDescription);