using FluentValidation;
using MascaradeApp.WebAPI.DTO;

namespace MascaradeApp.WebAPI.Validations;

public class CustomerCreateValidation: AbstractValidator<CustomerCreateDto>
{
    public CustomerCreateValidation()
    {
        RuleFor(x => x.FullName)
            .NotEmpty()
            .WithMessage($"FullName имя требуется");
        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Номер телефона обязателен.")
            .Matches(@"^\+?[0-9]{7,15}$").WithMessage("Неверный формат номера телефона.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email обязателен.")
            .EmailAddress().WithMessage("Неверный формат email.");
    }
}