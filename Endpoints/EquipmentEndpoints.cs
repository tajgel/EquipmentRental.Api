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
        app.MapGet("/equipment", async (AppDbContext dbContext, ClaimsPrincipal user) =>
        {

            var itemki = await dbContext.Equipments.Select(item => new EquipmentGetDtos(
                Id: item.Id,
                Name: item.Name,
                Category: item.Category,
                DailyPrice: item.DailyPrice,
                IsAvailable: item.IsAvailable
            )).ToListAsync();

            return Results.Ok(itemki);
        }).RequireAuthorization();
        app.MapPost("/equipment", async (EquipmentPostDto item, AppDbContext dbContext) =>
        {
            dbContext.Equipments.AddAsync(
                new Equipment
                {
                    Name = item.Name,
                    Category = item.Category,
                    DailyPrice = item.DailyPrice,
                    IsAvailable = item.IsAvailable
                }
            );
            await dbContext.SaveChangesAsync();
            return Results.Created();
        }).RequireAuthorization();
    }
}