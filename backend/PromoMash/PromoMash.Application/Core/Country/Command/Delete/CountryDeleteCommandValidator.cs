using FluentValidation;

namespace PromoMash.Application.Core.Country.Command.Delete;

public class CountryDeleteCommandValidator : AbstractValidator<CountryDeleteCommand>
{
    public CountryDeleteCommandValidator()
    {
        RuleFor(c => c.Id).NotNull().NotEqual(string.Empty);
    }
}