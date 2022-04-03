using FluentValidation;

namespace PromoMash.Application.Core.Province.Command.Delete;

public class ProvinceDeleteCommandValidator : AbstractValidator<ProvinceDeleteCommand>
{
    public ProvinceDeleteCommandValidator()
    {
        RuleFor(c => c.Id).NotNull().NotEqual(string.Empty);
    }
}