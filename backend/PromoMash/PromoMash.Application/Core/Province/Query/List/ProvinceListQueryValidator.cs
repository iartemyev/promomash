using FluentValidation;

namespace PromoMash.Application.Core.Province.Query.List;

public class ProvinceListQueryValidator : AbstractValidator<ProvinceListQuery>
{
    public ProvinceListQueryValidator()
    {
        RuleFor(c => c.CountryId).NotNull().NotEmpty();
    }
}