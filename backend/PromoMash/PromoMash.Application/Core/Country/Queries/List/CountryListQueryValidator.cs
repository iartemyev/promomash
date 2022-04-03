using FluentValidation;

namespace PromoMash.Application.Core.Country.Queries.List;

public class CountryListQueryValidator : AbstractValidator<CountryListQuery>
{
    public CountryListQueryValidator()
    {
        RuleFor(c => c.Text).MaximumLength(250);
    }
}