using EquipmentRental.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace EquipmentRental.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Equipment> Equipments => Set<Equipment>();
    public DbSet<Rental> Rentals => Set<Rental>();
    public DbSet<User> Users => Set<User>();
}