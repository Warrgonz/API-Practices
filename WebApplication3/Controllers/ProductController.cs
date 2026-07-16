using Microsoft.AspNetCore.Mvc;
using WebApplication3.DTOs;
using WebApplication3.Models;

namespace WebApplication3.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    // Esto simula una base de datos mientras aprendemos el funcionamiento del endpoint.
    private static readonly List<Product> Products = [];
    
    
    [HttpPost(Name = "AddProduct")]
    public IActionResult CreateProduct(CreateProductDto request)
    {
        if (string.IsNullOrEmpty(request.Name))
        {
            return BadRequest("Name is required");
        }

        if (request.Price <= 0)
        {
            return BadRequest("Price must be greater than zero");
        }

        if (request.Stock < 0)
        {
            return BadRequest("Product cannot be negative");
        }

        // Instancia del objeto
        Product product = new Product
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Price = request.Price,
            Stock = request.Stock,
            IsActive = true,
            CreatedDate = DateTime.UtcNow
        };
        
        Products.Add(product);
        
        return Created($"/api/product/{product.Id}", product);
        
//        return CreatedAtAction(
//            nameof(GetById),
//            new { id = product.Id },
//            product
//        );
    }

    [HttpGet("{id:guid}", Name = "GetProduct")]
    public IActionResult GetProduct(Guid id)
    {
        // Esa línea busca un producto dentro de la lista por su Id.
        Product? product = Products.FirstOrDefault(p => p.Id == id);

        if (product == null)
        {
            return NotFound("Product not found");
        }
        
        return Ok(product);
    }
}