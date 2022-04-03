using AutoMapper;
using PromoMash.Application.Common.Mapping;
using PromoMash.Domain.Core;

namespace PromoMash.Application.Core.Country.Queries.Read;

public class CountryVm : IMapWith<CountryEntity>
{
    public string Id { get; set; }
    
    public long CreatedAt { get; set; }
    
    public long? UpdatedAt { get; set; }
    
    public string Name { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CountryEntity, CountryVm>();
    }
}