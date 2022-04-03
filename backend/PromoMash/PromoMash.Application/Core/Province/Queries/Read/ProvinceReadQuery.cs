using MediatR;

namespace PromoMash.Application.Core.Province.Queries.Read;

public class ProvinceReadQuery : IRequest<ProvinceVm>
{
    public string Id { get; set; }
}