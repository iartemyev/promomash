using FluentValidation;

namespace PromoMash.Application.Core.Country.Command.Update;

public class CountryUpdateCommandValidator : AbstractValidator<CountryUpdateCommand>
{
    public CountryUpdateCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MaximumLength(250);
        RuleFor(c => c.Id).NotNull().NotEqual(string.Empty);
    }
}