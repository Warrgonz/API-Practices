// src: DTOs/ProductDto.cs

namespace WebApplication3.DTOs;

// Data Transfer Object
public class CreateProductDto
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    
    // El DTO representa solamente los datos que quiero recibir y enviar por la API.
    
}