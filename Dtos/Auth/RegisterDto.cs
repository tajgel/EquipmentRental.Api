using System.ComponentModel.DataAnnotations;

namespace EquipmentRental.Api.Dtos.Auth;

public record RegisterDto(
    [Required] string Email,
    [Required] [MinLength(6)] string Password
    );