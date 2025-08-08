using InmobiliariaAPI.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace InmobiliariaAPI.Models.DTOs;

public class UpdatePropertyRequest
{
    [Required(ErrorMessage = "El título es requerido")]
    [StringLength(200, ErrorMessage = "El título no puede exceder 200 caracteres")]
    public string Title { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "El precio es requerido")]
    [Range(1, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
    public decimal Price { get; set; }
    
    [Required(ErrorMessage = "La ubicación es requerida")]
    [StringLength(300, ErrorMessage = "La ubicación no puede exceder 300 caracteres")]
    public string Location { get; set; } = string.Empty;
    
    [StringLength(1000, ErrorMessage = "La descripción no puede exceder 1000 caracteres")]
    public string? Description { get; set; }
    
    [Range(0, 20, ErrorMessage = "El número de habitaciones debe estar entre 0 y 20")]
    public int Bedrooms { get; set; }
    
    [Range(0, 20, ErrorMessage = "El número de baños debe estar entre 0 y 20")]
    public int Bathrooms { get; set; }
    
    [Range(1, 10000, ErrorMessage = "El área debe estar entre 1 y 10000 m²")]
    public int Area { get; set; }
    
    public PropertyType PropertyType { get; set; }
    public PropertyStatus Status { get; set; }
}