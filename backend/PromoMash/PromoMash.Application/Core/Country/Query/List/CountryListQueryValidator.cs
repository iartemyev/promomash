using FluentValidation;

namespace PromoMash.Application.Core.Country.Query.List;

public class CountryListQueryValidator : AbstractValidator<CountryListQuery>
{
    public CountryListQueryValidator()
    {
        RuleFor(c => c.Text).MaximumLength(250);
    }
}