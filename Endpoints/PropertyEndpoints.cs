using InmobiliariaAPI.Models.DTOs;
using InmobiliariaAPI.Models.Entities;
using InmobiliariaAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace InmobiliariaAPI.Endpoints;

public static class PropertyEndpoints
{
    public static void MapPropertyEndpoints(this WebApplication app)
    {
        var propertyGroup = app.MapGroup("/api/properties")
            .WithTags(["Properties"])
            .WithOpenApi();

        // GET: Obtener propiedades con paginación
        propertyGroup.MapGet("/", async (
            [FromServices] IPropertyService propertyService,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10) =>
        {
            var response = await propertyService.GetPropertiesAsync(page, pageSize);
            return Results.Ok(response);
        })
        .WithName("GetProperties")
        .Produces<PagedResponse<Property>>(StatusCodes.Status200OK);

        // GET: Obtener propiedad por ID
        propertyGroup.MapGet("/{id}", async (
            [FromServices] IPropertyService propertyService,
            int id) =>
        {
            var property = await propertyService.GetPropertyByIdAsync(id);
            return property is not null ? Results.Ok(property) : Results.NotFound();
        })
        .WithName("GetProperty")
        .Produces<Property>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        // POST: Crear nueva propiedad
        propertyGroup.MapPost("/", async (
            [FromServices] IPropertyService propertyService,
            [FromBody] CreatePropertyRequest request) =>
        {
            // Validar datos
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(request);
            
            if (!Validator.TryValidateObject(request, validationContext, validationResults, true))
            {
                return Results.ValidationProblem(validationResults
                    .GroupBy(v => v.MemberNames.FirstOrDefault() ?? string.Empty)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Select(x => x.ErrorMessage ?? string.Empty).ToArray()
                    ));
            }

            var property = await propertyService.CreatePropertyAsync(request);
            return Results.Created($"{property.Id}", property);
        })
        .WithName("CreateProperty")
        .Produces<Property>(StatusCodes.Status201Created)
        .Produces<HttpValidationProblemDetails>(StatusCodes.Status400BadRequest);

        // PUT: Actualizar propiedad existente
        propertyGroup.MapPut("/{id}", async (
            [FromServices] IPropertyService propertyService,
            int id,
            [FromBody] UpdatePropertyRequest request) =>
        {
            // Validar datos
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(request);
            
            if (!Validator.TryValidateObject(request, validationContext, validationResults, true))
            {
                return Results.ValidationProblem(validationResults
                    .GroupBy(v => v.MemberNames.FirstOrDefault() ?? string.Empty)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Select(x => x.ErrorMessage ?? string.Empty).ToArray()
                    ));
            }

            var property = await propertyService.UpdatePropertyAsync(id, request);
            return property is not null ? Results.Ok(property) : Results.NotFound();
        })
        .WithName("UpdateProperty")
        .Produces<Property>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound)
        .Produces<HttpValidationProblemDetails>(StatusCodes.Status400BadRequest);

        // DELETE: Eliminar propiedad
        propertyGroup.MapDelete("/{id}", async (
            [FromServices] IPropertyService propertyService,
            int id) =>
        {
            var result = await propertyService.DeletePropertyAsync(id);
            return result ? Results.NoContent() : Results.NotFound();
        })
        .WithName("DeleteProperty")
        .Produces(StatusCodes.Status204NoContent)
        .Produces(StatusCodes.Status404NotFound);
    }
}
