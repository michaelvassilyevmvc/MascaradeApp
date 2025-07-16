namespace MascaradeApp.WebAPI.Enums;

[Flags]
public enum CostumeCategory
{
    None = 0,
    Historical = 1,
    Fantasy = 2,
    Horror = 4,
    Superhero = 8,
    National = 16,
    Animal = 32,
    SciFi = 64
}
