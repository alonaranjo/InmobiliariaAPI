using InmobiliariaAPI.Models.DTOs;
using InmobiliariaAPI.Models.Entities;

namespace InmobiliariaAPI.Services;

public interface IPropertyService
{
    Task<PagedResponse<Property>> GetPropertiesAsync(int page, int pageSize);
    Task<Property?> GetPropertyByIdAsync(int id);
    Task<Property> CreatePropertyAsync(CreatePropertyRequest request);
    Task<Property?> UpdatePropertyAsync(int id, UpdatePropertyRequest request);
    Task<bool> DeletePropertyAsync(int id);
}
