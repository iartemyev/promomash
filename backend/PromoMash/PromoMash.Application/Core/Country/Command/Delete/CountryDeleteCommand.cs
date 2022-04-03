using MediatR;

namespace PromoMash.Application.Core.Country.Command.Delete;

public class CountryDeleteCommand : IRequest
{
    public string Id { get; set; }

    public CountryDeleteCommand(string id)
    {
        Id = id ?? throw new ArgumentNullException(nameof(id));
    }
}