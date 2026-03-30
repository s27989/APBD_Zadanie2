namespace EquipmentRentalSystem.Models;

public abstract class User {
    public string Id { get; set; } = Guid.NewGuid().ToString().Substring(0, 5);
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public abstract int MaxRentals { get; }
}

public class Student : User { public override int MaxRentals => 2; }
public class Employee : User { public override int MaxRentals => 5; }