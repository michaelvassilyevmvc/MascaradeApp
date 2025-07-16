using MascaradeApp.WebAPI.Enums;

namespace MascaradeApp.WebAPI.Models;

public class Costume
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Size { get; set; } = string.Empty;

    public CostumeCategory Category { get; set; }

    public bool IsAvailable { get; set; }
    public decimal PricePerDay { get; set; }

    public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}
