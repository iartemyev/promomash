using AutoMapper;
using PromoMash.Application.Common.Mapping;
using PromoMash.Application.Core.Country.Commands.Update;

namespace PromoMash.WebApi.Model.Country;

public class CountryUpdateDto : IMapWith<CountryUpdateCommand>
{
    public string Name { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CountryCreateDto, CountryUpdateCommand>();
    }
}