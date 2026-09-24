namespace EquipmentRental.Api.Entities;

public class Equipment
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public string DailyPrice { get; set; }
    public string IsAvailable { get; set; }
}