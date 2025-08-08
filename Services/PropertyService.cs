using InmobiliariaAPI.Data.Repositories;
using InmobiliariaAPI.Models.DTOs;
using InmobiliariaAPI.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace InmobiliariaAPI.Services;

public class PropertyService : IPropertyService
{
    private readonly IPropertyRepository _propertyRepository;

    public PropertyService(IPropertyRepository propertyRepository)
    {
        _propertyRepository = propertyRepository;
    }

    public async Task<PagedResponse<Property>> GetPropertiesAsync(int page, int pageSize)
    {
        return await _propertyRepository.GetPagedAsync(page, pageSize);
    }

    public async Task<Property?> GetPropertyByIdAsync(int id)
    {
        return await _propertyRepository.GetByIdAsync(id);
    }

    public async Task<Property> CreatePropertyAsync(CreatePropertyRequest request)
    {
        var property = new Property
        {
            Title = request.Title,
            Price = request.Price,
            Location = request.Location,
            Description = request.Description,
            Bedrooms = request.Bedrooms,
            Bathrooms = request.Bathrooms,
            Area = request.Area,
            PropertyType = request.PropertyType,
            Status = request.Status,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await _propertyRepository.AddAsync(property);
        return property;
    }

    public async Task<Property?> UpdatePropertyAsync(int id, UpdatePropertyRequest request)
    {
        var property = await _propertyRepository.GetByIdAsync(id);
        if (property is null)
            return null;

        property.Title = request.Title;
        property.Price = request.Price;
        property.Location = request.Location;
        property.Description = request.Description;
        property.Bedrooms = request.Bedrooms;
        property.Bathrooms = request.Bathrooms;
        property.Area = request.Area;
        property.PropertyType = request.PropertyType;
        property.Status = request.Status;
        property.UpdatedAt = DateTime.UtcNow;

        _propertyRepository.Update(property);
        return property;
    }

    public async Task<bool> DeletePropertyAsync(int id)
    {
        var property = await _propertyRepository.GetByIdAsync(id);
        if (property is null)
            return false;

        _propertyRepository.Remove(property);
        return true;
    }
}
