using System.ComponentModel.DataAnnotations;

namespace EquipmentRental.Api.Dtos;

public record EquipmentPostDto (
     [Required] [StringLength(maximumLength:40)] string Name,
     [Required] [StringLength(maximumLength:50)]string Category,
     [Required] decimal DailyPrice,
     [Required] bool IsAvailable
);