using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MascaradeApp.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomersData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "FullName", "PhoneNumber", "RegisteredAt" },
                values: new object[,]
                {
                    { 1, "ivan.ivanov@example.com", "Иван Иванов", "+77001111111", new DateTime(2024, 1, 10, 9, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, "olga.petrova@example.com", "Ольга Петрова", "+77002222222", new DateTime(2024, 2, 15, 14, 30, 0, 0, DateTimeKind.Utc) },
                    { 3, "sergey.smirnov@example.com", "Сергей Смирнов", "+77003333333", new DateTime(2024, 3, 1, 12, 0, 0, 0, DateTimeKind.Utc) },
                    { 4, "anna.kuznetsova@example.com", "Анна Кузнецова", "+77004444444", new DateTime(2024, 3, 20, 10, 45, 0, 0, DateTimeKind.Utc) },
                    { 5, "dmitry.volkov@example.com", "Дмитрий Волков", "+77005555555", new DateTime(2024, 4, 5, 16, 0, 0, 0, DateTimeKind.Utc) },
                    { 6, "elena.novikova@example.com", "Елена Новикова", "+77006666666", new DateTime(2024, 4, 15, 11, 20, 0, 0, DateTimeKind.Utc) },
                    { 7, "alexey.morozov@example.com", "Алексей Морозов", "+77007777777", new DateTime(2024, 5, 1, 9, 15, 0, 0, DateTimeKind.Utc) },
                    { 8, "maria.sokolova@example.com", "Мария Соколова", "+77008888888", new DateTime(2024, 5, 18, 13, 0, 0, 0, DateTimeKind.Utc) },
                    { 9, "nikita.fedorov@example.com", "Никита Фёдоров", "+77009999999", new DateTime(2024, 6, 1, 10, 30, 0, 0, DateTimeKind.Utc) },
                    { 10, "tatyana.pavlova@example.com", "Татьяна Павлова", "+77001010101", new DateTime(2024, 6, 10, 15, 45, 0, 0, DateTimeKind.Utc) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
