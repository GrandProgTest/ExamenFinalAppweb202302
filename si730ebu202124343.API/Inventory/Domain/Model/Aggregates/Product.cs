using System.ComponentModel.DataAnnotations.Schema;
using si730ebu202124343.API.Inventory.Domain.Model.Commands;
using si730ebu202124343.API.Inventory.Domain.Model.ValueObjects;

namespace si730ebu202124343.API.Inventory.Domain.Model.Aggregates;
    
public class Product 
{
    public int Id { get; set; }

    public string Brand { get; set; }

    public string Model { get; set; }

    public string SerialNumber { get; set; }

    public Status Status { get; set; }

    [NotMapped]
    public string StatusDescription
    {
        get
        {
            return Status == Status.Operational ? "OPERATIONAL" : "UNOPERATIONAL";
        }
        set
        {
            Status = value == "OPERATIONAL" ? Status.Operational : Status.Unoperational;
        }
    }

    public Product()
    {
        
    }
    public Product(CreateProductCommand command)
    {
        this.Brand = command.Brand;
        this.Model = command.Model;
        this.SerialNumber = command.SerialNumber;
        this.StatusDescription = command.StatusDescription;
    }
}
