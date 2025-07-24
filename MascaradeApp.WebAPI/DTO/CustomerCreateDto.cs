using MascaradeApp.WebAPI.Entities;

namespace MascaradeApp.WebAPI.DTO;

public class CustomerCreateDto
{
    public string FullName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    // public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}