using InmobiliariaAPI.Models.Entities;
using InmobiliariaAPI.Models.DTOs;

namespace InmobiliariaAPI.Data.Repositories;

public class PropertyRepository : Repository<Property>, IPropertyRepository
{
    public PropertyRepository(PropertyDbContext context) : base(context) { }

    public async Task<PagedResponse<Property>> GetByTypeAsync(PropertyType type, int page, int pageSize)
    {
        return await GetPagedAsync(
            page,
            pageSize,
            p => p.PropertyType == type);
    }

    public async Task<PagedResponse<Property>> GetByStatusAsync(PropertyStatus status, int page, int pageSize)
    {
        return await GetPagedAsync(
            page,
            pageSize,
            p => p.Status == status);
    }

    public async Task<PagedResponse<Property>> SearchAsync(string searchTerm, int page, int pageSize)
    {
        var normalizedSearchTerm = searchTerm.ToLower();
        
        return await GetPagedAsync(
            page,
            pageSize,
            p => p.Title.ToLower().Contains(normalizedSearchTerm) ||
                 p.Description != null && p.Description.ToLower().Contains(normalizedSearchTerm) ||
                 p.Location.ToLower().Contains(normalizedSearchTerm));
    }
}
