using System.ComponentModel.DataAnnotations;

namespace InmobiliariaAPI.Models.Entities;

public class Property
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;
    
    [Required]
    [Range(1, double.MaxValue)]
    public decimal Price { get; set; }
    
    [Required]
    [StringLength(300)]
    public string Location { get; set; } = string.Empty;
    
    [StringLength(1000)]
    public string? Description { get; set; }
    
    [Range(0, 20)]
    public int Bedrooms { get; set; }
    
    [Range(0, 20)]
    public int Bathrooms { get; set; }
    
    [Range(1, 10000)]
    public int Area { get; set; } // Área en metros cuadrados
    
    public PropertyType PropertyType { get; set; }
    public PropertyStatus Status { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}