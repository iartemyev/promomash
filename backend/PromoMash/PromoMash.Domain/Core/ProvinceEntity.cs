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
    
    public void SetName(string name)
    {
        Name = name;
        UpdatedAt = DateTime.UtcNow.ToUnixTimeMilliseconds();
    }
}