using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using EquipmentRental.Api.Data;
using EquipmentRental.Api.Dtos.Auth;
using EquipmentRental.Api.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace EquipmentRental.Api.Endpoints;

public class AuthEndpoints
{
    public static void MapAuth(WebApplication app)
    {
        app.MapPost("/register", async (AppDbContext dbContext, RegisterDto regDto) =>
        {
            if (await dbContext.Users.AnyAsync(user => user.Email == regDto.Email))
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
        app.MapPost("/login", async (AppDbContext dbContext, LoginDto logDto, IConfiguration configuration) =>
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(user => user.Email == logDto.Email);
            if (user == null) return Results.BadRequest("Bad email or password");

            var hasher = new PasswordHasher<User>();
            if (hasher.VerifyHashedPassword(user, user.PasswordHash, logDto.Password) !=
                PasswordVerificationResult.Success)
            {
                return Results.BadRequest("Bad email or password");
            }

            var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!);
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };
            var token = new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken
            (
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256
                )
            ));
            return Results.Ok(new {token});
            
            // var jwtSecurityToken = 
            return Results.Ok();
        });
    }
}