using MediatR;

namespace PromoMash.Application.Core.Province.Queries.List;

public class ProvinceListQuery : IRequest<ProvinceListVm>
{
    public string CountryId { get; set; }
}