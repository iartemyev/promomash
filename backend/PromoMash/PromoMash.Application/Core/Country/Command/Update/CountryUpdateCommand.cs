using MediatR;

namespace PromoMash.Application.Core.Country.Command.Update;

public class CountryUpdateCommand : IRequest
{
    public string Id { get; set; }
    
    public string Name { get; set; }
}