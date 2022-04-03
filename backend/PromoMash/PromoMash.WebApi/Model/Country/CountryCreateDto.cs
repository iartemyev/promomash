using AutoMapper;
using PromoMash.Application.Common.Mapping;
using PromoMash.Application.Core.Country.Commands.Create;

namespace PromoMash.WebApi.Model.Country;

public class CountryCreateDto : IMapWith<CountryCreateCommand>
{
    public string Name { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CountryCreateDto, CountryCreateCommand>();
    }
}