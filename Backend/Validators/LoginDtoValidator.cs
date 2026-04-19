using Backend.DTOs;
using FluentValidation;

namespace Backend.Validators;

public class LoginDtoValidator : AbstractValidator<LoginDto>
{
    public LoginDtoValidator()
    {
        RuleFor(dto => dto.Username).NotEmpty().WithMessage("Nazwa użytkownika jest wymagana");
        RuleFor(dto => dto.Password).NotEmpty().WithMessage("Hasło jest wymagane");
    }
}