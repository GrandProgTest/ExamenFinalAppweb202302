using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using si730ebu202124343.API.Inventory.Domain.Model.Queries;
using si730ebu202124343.API.Inventory.Domain.Services;
using si730ebu202124343.API.Inventory.Interfaces.REST.Resources;
using si730ebu202124343.API.Inventory.Interfaces.REST.Transform;

namespace si730ebu202124343.API.Inventory.Interfaces.REST;


[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class ProductsController(
    IProductCommandService productCommandService,
    IProductQueryService productQueryService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductResource resource)
    {
        var command = CreateProductCommandFromResourceAssembler.ToCommandFromResource(resource);
        var product = await productCommandService.Handle(command);
        if (product == null)
            return BadRequest();
        var productResource = ProductResourceFromEntityAssembler.ToResourceFromEntity(product);
        return CreatedAtAction(nameof(GetProductById), new { productId = product.Id }, productResource);
    }
    
    
    [HttpGet("{productId:int}")]
    public async Task<IActionResult> GetProductById(int productId)
    {
        var query = new GetProductByIdQuery(productId);
        var product = await productQueryService.Handle(query);
        if (product == null)
            return NotFound();
        var productResource = ProductResourceFromEntityAssembler.ToResourceFromEntity(product);
        return Ok(productResource);
    }
}