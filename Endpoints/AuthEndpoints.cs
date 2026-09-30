using EquipmentRental.Api.Data;
using EquipmentRental.Api.Dtos.Auth;
using EquipmentRental.Api.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EquipmentRental.Api.Endpoints;

public class AuthEndpoints
{
    public static void MapAuth(WebApplication app)
    {
        app.MapPost("/register", async (AppDbContext dbContext, RegisterDto regDto) =>
        {
            if(await dbContext.Users.AnyAsync(user => user.Email == regDto.Email))
            {
                return Results.BadRequest("User already exists");
            }

            var hashedPass = new PasswordHasher<User>();
            var newUser = new User
            {
                Email = regDto.Email,
                Role = Role.User
            };
            newUser.PasswordHash = hashedPass.HashPassword(newUser, regDto.Password);
            dbContext.Users.Add(newUser);
            await dbContext.SaveChangesAsync();
            return Results.Ok();
        });
    }
}