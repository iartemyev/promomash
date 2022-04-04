using PromoMash.Domain.Common;
using PromoMash.Domain.Extensions;

namespace PromoMash.Domain.Core;

public class CountryEntity : PromoMashEntity
{
    public string Name { get; private set; }

    public ICollection<ProvinceEntity> Provinces { get; private set; }

    public CountryEntity(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public void SetName(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        UpdatedAt = DateTime.UtcNow.ToUnixTimeMilliseconds();
    }
}