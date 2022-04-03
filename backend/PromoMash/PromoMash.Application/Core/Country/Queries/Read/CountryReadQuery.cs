using MediatR;

namespace PromoMash.Application.Core.Country.Queries.Read;

public class CountryReadQuery : IRequest<CountryVm>
{
    public string Id { get; set; }

    public CountryReadQuery(string id)
    {
        Id = id ?? throw new ArgumentNullException(nameof(id));
    }
}