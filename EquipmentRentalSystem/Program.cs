using EquipmentRentalSystem.Models;
using EquipmentRentalSystem.Services;

var rs = new RentalService();
var l1 = new Laptop { Name = "MacBook" };
var s1 = new Student { FirstName = "Anna", LastName = "Bąk" };

rs.AddEquipment(l1);
rs.AddUser(s1);

try {
    rs.RentItem(s1, l1);
    Console.WriteLine("Wypożyczono poprawnie.");
    rs.RentItem(s1, l1);
} catch (Exception ex) {
    Console.WriteLine($"Błąd: {ex.Message}");
}

rs.ReturnItem(l1);
rs.ShowAll();