using MediatR;

namespace PromoMash.Application.Core.Province.Commands.Create;

public class ProvinceCreateCommand : IRequest<string>
{
    public string Name { get; set; }
}