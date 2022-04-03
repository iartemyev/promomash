using MediatR;

namespace PromoMash.Application.Core.Province.Command.Create;

public class ProvinceCreateCommand : IRequest<string>
{
    public string Name { get; set; }
}