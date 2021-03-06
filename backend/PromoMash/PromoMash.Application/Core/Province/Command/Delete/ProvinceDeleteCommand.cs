using MediatR;

namespace PromoMash.Application.Core.Province.Command.Delete;

public class ProvinceDeleteCommand : IRequest
{
    public string Id { get; set; }

    public ProvinceDeleteCommand(string id)
    {
        Id = id ?? throw new ArgumentNullException(nameof(id));
    }
}