using MascaradeApp.WebAPI.Entities;

namespace MascaradeApp.WebAPI.Entities;

public class Rental
{
    public int Id { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; }

    public int CostumeId { get; set; }
    public Costume Costume { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public decimal TotalPrice { get; set; }
}
