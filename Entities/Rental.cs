namespace EquipmentRental.Api.Entities;

public class Rental
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int EquipmentId { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public int TotalPrice { get; set; }
}