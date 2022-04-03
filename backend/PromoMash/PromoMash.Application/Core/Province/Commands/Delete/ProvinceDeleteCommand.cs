using MediatR;

namespace PromoMash.Application.Core.Province.Commands.Delete;

public class ProvinceDeleteCommand : IRequest
{
    public string Id { get; set; }
}