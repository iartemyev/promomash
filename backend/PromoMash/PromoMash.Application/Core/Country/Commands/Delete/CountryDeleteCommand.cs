using MediatR;

namespace PromoMash.Application.Core.Country.Commands.Delete;

public class CountryDeleteCommand : IRequest
{
    public string Id { get; set; }
}