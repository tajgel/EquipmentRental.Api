namespace EquipmentRental.Api.Entities;

public class User
{
    public  int Id { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; } = string.Empty;
    public Role Role { get; set; }
}

public enum Role
{
    User,
    Admin
}