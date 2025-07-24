namespace MascaradeApp.WebAPI.DTO;

public class CostumeCreateDto
{
    public string Name { get; set; } = string.Empty;
    public string Size { get; set; } = string.Empty;
    public int Category { get; set; }
    public bool IsAvailable { get; set; }
    public decimal PricePerDay { get; set; }
}