using MediatR;

namespace PromoMash.Application.Core.Country.Commands.Create;

public class CountryCreateCommand : IRequest<string>
{
    public string Name { get; set; }
}