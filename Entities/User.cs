namespace EquipmentRental.Api.Entities;

public class User
{
    public  int Id { get; set; }
    public string Email { get; set; }
    //TODO later
    // public HashCode PasswordHash { get; set; }
    public Role Role { get; set; }
}

public enum Role
{
    User,
    Admin
}