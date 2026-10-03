using System.ComponentModel.DataAnnotations;

namespace EquipmentRental.Api.Dtos.Auth;

public record LoginDto(
    [Required] string Email,
    [Required] [MinLength(6)] string Password
);