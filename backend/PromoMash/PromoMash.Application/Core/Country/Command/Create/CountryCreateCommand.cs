using MediatR;

namespace PromoMash.Application.Core.Country.Command.Create;

public class CountryCreateCommand : IRequest<string>
{
    public string Name { get; set; }
}