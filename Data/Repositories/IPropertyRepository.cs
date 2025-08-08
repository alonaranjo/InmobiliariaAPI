using InmobiliariaAPI.Models.DTOs;
using InmobiliariaAPI.Models.Entities;

namespace InmobiliariaAPI.Data.Repositories;

public interface IPropertyRepository : IRepository<Property>
{
    Task<PagedResponse<Property>> GetByTypeAsync(PropertyType type, int page, int pageSize);
    Task<PagedResponse<Property>> GetByStatusAsync(PropertyStatus status, int page, int pageSize);
    Task<PagedResponse<Property>> SearchAsync(string searchTerm, int page, int pageSize);
}
