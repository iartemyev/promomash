using FluentValidation;

namespace PromoMash.Application.Core.Country.Commands.Create;

public class CountryCreateCommandValidator : AbstractValidator<CountryCreateCommand>
{
    public CountryCreateCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MaximumLength(250);
    }
}