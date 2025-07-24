namespace MascaradeApp.WebAPI.DTO;

public class CostumeUpdateDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Size { get; set; } = string.Empty;
    public int Category { get; set; }
    public bool IsAvailable { get; set; }
    public decimal PricePerDay { get; set; }
}