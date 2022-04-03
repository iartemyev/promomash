using AutoMapper;
using PromoMash.Application.Common.Mapping;
using PromoMash.Domain.Core;

namespace PromoMash.Application.Core.Province.Queries.List;

public class ProvinceLookupDto : IMapWith<ProvinceEntity>
{
    public string Id { get; set; }

    public string Name { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<ProvinceEntity, ProvinceLookupDto>();
    }
}