using FluentValidation;
using MascaradeApp.WebAPI.DTO;

namespace MascaradeApp.WebAPI.Validations;

public class CustomerUpdateValidation : AbstractValidator<CustomerUpdateDto>
{
    public CustomerUpdateValidation()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Идентификатор клиента должен быть положительным.");

        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage("Полное имя обязательно.")
            .MaximumLength(100)
            .WithMessage("Имя не должно превышать 100 символов.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .WithMessage("Номер телефона обязателен.")
            .Matches(@"^\+?[0-9]{7,15}$")
            .WithMessage("Неверный формат номера телефона.");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email обязателен.")
            .EmailAddress()
            .WithMessage("Неверный формат email.");

        RuleFor(x => x.RegisteredAt)
            .NotEmpty()
            .WithMessage("Дата регистрации обязательна.")
            .LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("Дата регистрации не может быть в будущем.");
    }
}