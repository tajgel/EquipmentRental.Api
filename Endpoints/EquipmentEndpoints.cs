using System.Security.Claims;
using EquipmentRental.Api.Data;
using EquipmentRental.Api.Dtos;
using EquipmentRental.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace EquipmentRental.Api.Endpoints;

public class EquipmentEndpoints
{
    public static void MapEquipment(WebApplication app)
    {
        app.MapGet("/equipment", async (AppDbContext dbContext) =>
        {
            var itemki = await dbContext.Equipments.Select(item => new EquipmentGetDtos(
                Id: item.Id,
                Name: item.Name,
                Category: item.Category,
                DailyPrice: item.DailyPrice,
                IsAvailable: item.IsAvailable
            )).ToListAsync();
            return Results.Ok(itemki);
        });
    }
}