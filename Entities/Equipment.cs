namespace EquipmentRental.Api.Entities;

public class Equipment
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public decimal DailyPrice { get; set; }
    public bool IsAvailable { get; set; }
}