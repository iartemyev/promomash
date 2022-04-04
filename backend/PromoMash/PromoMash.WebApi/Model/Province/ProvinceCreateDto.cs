using AutoMapper;
using PromoMash.Application.Common.Mapping;
using PromoMash.Application.Core.Province.Command.Create;

namespace PromoMash.WebApi.Model.Province;

public class ProvinceCreateDto : IMapWith<ProvinceCreateCommand>
{
    public string Name { get; set; }
    
    public string CountryId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ProvinceCreateDto, ProvinceCreateCommand>();
    }
}