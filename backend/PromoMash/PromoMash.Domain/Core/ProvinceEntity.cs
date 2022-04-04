using PromoMash.Domain.Common;
using PromoMash.Domain.Extensions;

namespace PromoMash.Domain.Core;

public class ProvinceEntity : PromoMashEntity
{
    public string Name { get; private set; }
    
    public CountryEntity Country { get; private set; }

    public ProvinceEntity(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public ProvinceEntity(string name, CountryEntity country)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Country = country ?? throw new ArgumentNullException(nameof(country));
    }

    public ProvinceEntity SetName(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        UpdatedAt = DateTime.UtcNow.ToUnixTimeMilliseconds();
        
        return this;
    }
    
    public ProvinceEntity SetCountryId(string countryId)
    {
        Country.Id = countryId ?? throw new ArgumentNullException(nameof(countryId));
        UpdatedAt = DateTime.UtcNow.ToUnixTimeMilliseconds();

        return this;
    }
}