using InmobiliariaAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace InmobiliariaAPI.Data;

public static class PropertySeeder
{
    public static async Task SeedData(PropertyDbContext context)
    {
        if (await context.Properties.AnyAsync())
            return;

        var properties = new List<Property>
        {
            new Property
            {
                Title = "Casa moderna en San José Centro",
                Price = 350000,
                Location = "San José Centro, San José, CR",
                Description = "Hermosa casa moderna con acabados de lujo",
                Bedrooms = 3,
                Bathrooms = 2,
                Area = 180,
                PropertyType = PropertyType.Casa,
                Status = PropertyStatus.Disponible,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Property
            {
                Title = "Apartamento con vista al mar",
                Price = 280000,
                Location = "Puntarenas, Puntarenas, CR",
                Description = "Apartamento de 2 habitaciones con vista panorámica",
                Bedrooms = 2,
                Bathrooms = 2,
                Area = 120,
                PropertyType = PropertyType.Apartamento,
                Status = PropertyStatus.Disponible,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Property
            {
                Title = "Oficina comercial céntrica",
                Price = 450000,
                Location = "San Pedro, San José, CR",
                Description = "Espaciosa oficina ideal para empresas",
                Bedrooms = 0,
                Bathrooms = 3,
                Area = 200,
                PropertyType = PropertyType.Comercial,
                Status = PropertyStatus.Disponible,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }
        };

        context.Properties.AddRange(properties);
        await context.SaveChangesAsync();
    }
}