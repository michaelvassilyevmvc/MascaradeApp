🧩 Структура и связи
* Customer (клиенты): кто арендует костюмы
* Costume (костюмы): что можно арендовать
* Rental (аренда): связующая таблица между клиентом и костюмом

✅ Модель классов на C# (.NET)
```csharp
public class Customer
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime RegisteredAt { get; set; }

    public ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}

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

```

3. Пример использования *Costume* 
```csharp
var costume = new Costume
{
    Name = "Vampire Lord",
    Size = "M",
    Category = CostumeCategory.Horror | CostumeCategory.Historical,
    IsAvailable = true,
    PricePerDay = 10
};
```