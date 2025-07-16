namespace MascaradeApp.WebAPI.Entities;

public class Customer
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime RegisteredAt { get; set; }

    public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}
