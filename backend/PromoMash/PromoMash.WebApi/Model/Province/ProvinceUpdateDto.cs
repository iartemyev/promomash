using AutoMapper;
using PromoMash.Application.Common.Mapping;
using PromoMash.Application.Core.Province.Command.Update;

namespace PromoMash.WebApi.Model.Province;

public class ProvinceUpdateDto : IMapWith<ProvinceUpdateCommand>
{
    public string Id { get; set; }
    
    public string Name { get; set; }
    
    public string CountryId { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<ProvinceUpdateDto, ProvinceUpdateCommand>();
    }
}