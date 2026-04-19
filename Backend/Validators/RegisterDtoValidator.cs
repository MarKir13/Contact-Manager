using Backend.DTOs;
using FluentValidation;

namespace Backend.Validators;

public class RegisterDtoValidator : AbstractValidator<RegisterDto>
{
    public RegisterDtoValidator()
    {
        RuleFor(dto => dto.Username).NotEmpty().WithMessage("Nazwa użytkownika jest wymagana")
        .MinimumLength(5).WithMessage("Nazwa użytkownika musi mieć co najmniej 5 znaków")
        .MaximumLength(100).WithMessage("Nazwa użytkownika może mieć maksymalnie 100 znaków");

        RuleFor(dto => dto.Password).NotEmpty().WithMessage("Hasło jest wymagane")
        .MinimumLength(8).WithMessage("Haslo musi mieć co najmniej 8 znaków")
        .Matches("[A-Z]").WithMessage("Hasło musi zawierać wielką literę")
        .Matches("[a-z]").WithMessage("Hasło musi zawierać małą literę")
        .Matches("[0-9]").WithMessage("Hasło musi zawierać cyfrę")
        .Matches("[!@#$%&*?^]").WithMessage("Hasło musi zawierać jeden ze znaków specjalnych: ! @ # $ % ^ & * ?");
    }
}