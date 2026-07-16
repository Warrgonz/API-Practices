namespace WebApplication3.Models;

public class Product
{
    
    // Nunca expongas directamente tus entidades de dominio a la API.
    
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; }
}