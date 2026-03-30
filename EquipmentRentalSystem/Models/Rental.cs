namespace EquipmentRentalSystem.Models;

public class Rental {
    public Equipment Item { get; set; }
    public User Borrower { get; set; }
    public DateTime DateRented { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public bool IsOverdue => ReturnDate == null ? DateTime.Now > DueDate : ReturnDate > DueDate;
}