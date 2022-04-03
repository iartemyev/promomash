using MediatR;

namespace PromoMash.Application.Core.Province.Command.Update;

public class ProvinceUpdateCommand : IRequest
{
    public string Id { get; set; }
    
    public string Name { get; set; }
}