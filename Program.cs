using EquipmentRental.Api.Data;
using EquipmentRental.Api.Endpoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));



var app = builder.Build();
EquipmentEndpoints.MapEquipment(app);


app.Run();