using PromoMash.Domain.Common;

namespace PromoMash.Domain.Core;

public class Country : PromoMashEntity
{
    public string Name { get; private set; }
}