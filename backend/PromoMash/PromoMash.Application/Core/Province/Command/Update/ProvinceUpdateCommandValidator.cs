using FluentValidation;

namespace PromoMash.Application.Core.Province.Command.Update;

public class ProvinceUpdateCommandValidator : AbstractValidator<ProvinceUpdateCommand>
{
    public ProvinceUpdateCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MaximumLength(250);
        RuleFor(c => c.Id).NotNull().NotEqual(string.Empty);
        RuleFor(c => c.CountryId).NotNull().NotEmpty();
    }
}