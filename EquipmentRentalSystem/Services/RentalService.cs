namespace EquipmentRentalSystem.Services;

public class RentalService {
    private List<Equipment> _inventory = new();
    private List<User> _users = new();
    private List<Rental> _rentals = new();
    private const decimal DailyPenalty = 10.0m; // Łatwa zmiana kary [cite: 49]

    public void AddEquipment(Equipment e) => _inventory.Add(e); // [cite: 35]
    public void AddUser(User u) => _users.Add(u); // [cite: 34]

    public void RentItem(User user, Equipment item) {
        var activeCount = _rentals.Count(r => r.Borrower.Id == user.Id && r.ReturnDate == null);
        
        if (!item.IsAvailable) throw new Exception("Sprzęt jest niedostępny!"); // [cite: 46]
        if (activeCount >= user.MaxRentals) throw new Exception("Przekroczono limit wypożyczeń!"); // [cite: 47]

        item.IsAvailable = false;
        _rentals.Add(new Rental {
            Item = item, Borrower = user, DateRented = DateTime.Now, DueDate = DateTime.Now.AddDays(7)
        });
    }

    public decimal ReturnItem(Equipment item) {
        var rental = _rentals.FirstOrDefault(r => r.Item.Id == item.Id && r.ReturnDate == null);
        if (rental == null) return 0;

        rental.ReturnDate = DateTime.Now;
        item.IsAvailable = true;

        [cite_start]if (rental.IsOverdue) { // Obliczanie kary [cite: 39, 48]
            int daysLate = (rental.ReturnDate.Value - rental.DueDate).Days;
            return daysLate * DailyPenalty;
        }
        return 0;
    }

    [cite_start]// Raporty [cite: 36, 37, 42, 43]
    public void ShowAll() => _inventory.ForEach(e => Console.WriteLine($"[{e.Id}] {e.Name} - Dostępny: {e.IsAvailable}"));
    public void ShowAvailable() => _inventory.Where(e => e.IsAvailable).ToList().ForEach(e => Console.WriteLine(e.GetInfo()));
    public void ShowOverdue() => _rentals.Where(r => r.IsOverdue && r.ReturnDate == null).ToList().ForEach(r => Console.WriteLine($"Spóźnienie: {r.Borrower.LastName} - {r.Item.Name}"));
}