using Backend.DTOs;
using FluentValidation;

namespace Backend.Validators;

public class CreateContactDtoValidator : AbstractValidator<CreateContactDto>
{
    public CreateContactDtoValidator()
    {
        RuleFor(dto => dto.Name).NotEmpty().WithMessage("Imię jest wymagane")
        .MaximumLength(50).WithMessage("Imię nie może mieć więcej niz 50 znaków");
        
        RuleFor(dto => dto.Name).NotEmpty().WithMessage("Nazwisko jest wymagane")
        .MaximumLength(50).WithMessage("Nazwisko nie może mieć więcej niz 50 znaków");

        RuleFor(dto => dto.Email).NotEmpty().WithMessage("Email jest wymagany")
        .MaximumLength(100).WithMessage("Email nie może mieć więcej niż 100 znaków")
        .EmailAddress().WithMessage("Podany email nie jest poprawnym adresem email");

        RuleFor(dto => dto.PhoneNumber).NotEmpty().WithMessage("Imię jest wymagane")
        .MaximumLength(15).WithMessage("Numer telefonu nie może mieć więcej niz 15 cyfr")
        .Matches("^[0-9]+$").WithMessage("Numer telefonu musi składać się z samych cyfr");

        RuleFor(dto => dto.Password).NotEmpty().WithMessage("Hasło jest wymagane")
        .MinimumLength(8).WithMessage("Haslo musi mieć co najmniej 8 znaków")
        .Matches("[A-Z]").WithMessage("Hasło musi zawierać wielką literę")
        .Matches("[a-z]").WithMessage("Hasło musi zawierać małą literę")
        .Matches("[0-9]").WithMessage("Hasło musi zawierać cyfrę")
        .Matches("[!@#$%&*?^]").WithMessage("Hasło musi zawierać jeden ze znaków specjalnych: ! @ # $ % ^ & * ?");
    }
}