using AutoMapper;
using PromoMash.Application.Common.Mapping;
using PromoMash.Domain.Core;

namespace PromoMash.Application.Core.Country.Queries.List;

public class CountryLookupDto : IMapWith<CountryEntity>
{
    public string Id { get; set; }

    public string Name { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CountryEntity, CountryLookupDto>();
    }
}