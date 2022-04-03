using FluentValidation;

namespace PromoMash.Application.Core.Country.Queries.Read;

public class CountryReadQueryValidator : AbstractValidator<CountryReadQuery>
{
    public CountryReadQueryValidator()
    {
        RuleFor(c => c.Id).NotNull().NotEqual(string.Empty);
    }
}