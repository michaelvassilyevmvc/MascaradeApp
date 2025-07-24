using MascaradeApp.WebAPI.Enums;

namespace MascaradeApp.WebAPI.DTO;

public class CostumeDto
{
    public string Name { get; set; } = string.Empty;
    public string Size { get; set; } = string.Empty;
    public CostumeCategory Category { get; set; }
    public bool IsAvailable { get; set; }
    public decimal PricePerDay { get; set; }
}