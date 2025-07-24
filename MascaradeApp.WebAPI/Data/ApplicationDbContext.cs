using MascaradeApp.WebAPI.Entities;
using MascaradeApp.WebAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MascaradeApp.WebAPI.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<Costume> Costumes { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Rental> Rentals { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Customer>()
            .HasData(
                new Customer
                {
                    Id = 1,
                    FullName = "Иван Иванов",
                    PhoneNumber = "+77001111111",
                    Email = "ivan.ivanov@example.com",
                    RegisteredAt = new DateTime(2024, 1, 10, 9, 0, 0, DateTimeKind.Utc)
                },
                new Customer
                {
                    Id = 2,
                    FullName = "Ольга Петрова",
                    PhoneNumber = "+77002222222",
                    Email = "olga.petrova@example.com",
                    RegisteredAt = new DateTime(2024, 2, 15, 14, 30, 0, DateTimeKind.Utc)
                },
                new Customer
                {
                    Id = 3,
                    FullName = "Сергей Смирнов",
                    PhoneNumber = "+77003333333",
                    Email = "sergey.smirnov@example.com",
                    RegisteredAt = new DateTime(2024, 3, 1, 12, 0, 0, DateTimeKind.Utc)
                },
                new Customer
                {
                    Id = 4,
                    FullName = "Анна Кузнецова",
                    PhoneNumber = "+77004444444",
                    Email = "anna.kuznetsova@example.com",
                    RegisteredAt = new DateTime(2024, 3, 20, 10, 45, 0, DateTimeKind.Utc)
                },
                new Customer
                {
                    Id = 5,
                    FullName = "Дмитрий Волков",
                    PhoneNumber = "+77005555555",
                    Email = "dmitry.volkov@example.com",
                    RegisteredAt = new DateTime(2024, 4, 5, 16, 0, 0, DateTimeKind.Utc)
                },
                new Customer
                {
                    Id = 6,
                    FullName = "Елена Новикова",
                    PhoneNumber = "+77006666666",
                    Email = "elena.novikova@example.com",
                    RegisteredAt = new DateTime(2024, 4, 15, 11, 20, 0, DateTimeKind.Utc)
                },
                new Customer
                {
                    Id = 7,
                    FullName = "Алексей Морозов",
                    PhoneNumber = "+77007777777",
                    Email = "alexey.morozov@example.com",
                    RegisteredAt = new DateTime(2024, 5, 1, 9, 15, 0, DateTimeKind.Utc)
                },
                new Customer
                {
                    Id = 8,
                    FullName = "Мария Соколова",
                    PhoneNumber = "+77008888888",
                    Email = "maria.sokolova@example.com",
                    RegisteredAt = new DateTime(2024, 5, 18, 13, 0, 0, DateTimeKind.Utc)
                },
                new Customer
                {
                    Id = 9,
                    FullName = "Никита Фёдоров",
                    PhoneNumber = "+77009999999",
                    Email = "nikita.fedorov@example.com",
                    RegisteredAt = new DateTime(2024, 6, 1, 10, 30, 0, DateTimeKind.Utc)
                },
                new Customer
                {
                    Id = 10,
                    FullName = "Татьяна Павлова",
                    PhoneNumber = "+77001010101",
                    Email = "tatyana.pavlova@example.com",
                    RegisteredAt = new DateTime(2024, 6, 10, 15, 45, 0, DateTimeKind.Utc)
                }
            );

        base.OnModelCreating(builder);
    }
}