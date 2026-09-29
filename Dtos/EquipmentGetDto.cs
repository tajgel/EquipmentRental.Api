namespace EquipmentRental.Api.Dtos;

public record EquipmentGetDtos(
    int Id,
    string Name,
    string Category,
    decimal DailyPrice,
    bool IsAvailable
);