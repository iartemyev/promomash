using MediatR;

namespace PromoMash.Application.Core.Province.Commands.Update;

public class ProvinceUpdateCommand : IRequest
{
    public string Id { get; set; }
    
    public string Name { get; set; }
}