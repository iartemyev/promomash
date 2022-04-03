using MediatR;

namespace PromoMash.Application.Core.Province.Query.Read;

public class ProvinceReadQuery : IRequest<ProvinceVm>
{
    public string Id { get; set; }

    public ProvinceReadQuery(string id)
    {
        Id = id ?? throw new ArgumentNullException(nameof(id));
    }
}