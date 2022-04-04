using FluentValidation;

namespace PromoMash.Application.Core.Province.Command.Create;

public class ProvinceCreateCommandValidator : AbstractValidator<ProvinceCreateCommand>
{
    public ProvinceCreateCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().MaximumLength(250);
        RuleFor(c => c.CountryId).NotNull().NotEmpty();
    }
}