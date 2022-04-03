using MediatR;

namespace PromoMash.Application.Core.Province.Query.List;

public class ProvinceListQuery : IRequest<ProvinceListVm>
{
    public string CountryId { get; set; }

    public ProvinceListQuery(string countryId)
    {
        CountryId = countryId ?? throw new ArgumentNullException(nameof(countryId));
    }
}