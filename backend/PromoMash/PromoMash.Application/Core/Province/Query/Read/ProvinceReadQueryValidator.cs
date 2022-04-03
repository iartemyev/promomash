using FluentValidation;

namespace PromoMash.Application.Core.Province.Query.Read;

public class ProvinceReadQueryValidator : AbstractValidator<ProvinceReadQuery>
{
    public ProvinceReadQueryValidator()
    {
        RuleFor(c => c.Id).NotNull().NotEqual(string.Empty);
    }
}