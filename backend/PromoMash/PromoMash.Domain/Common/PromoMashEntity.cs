using PromoMash.Domain.Extensions;

namespace PromoMash.Domain.Common;

public abstract class PromoMashEntity : IEntity
{
    public long CreatedAt { get; protected set; } = DateTime.UtcNow.ToUnixTimeMilliseconds();
    
    public long? UpdatedAt { get; protected set; } = DateTime.UtcNow.ToUnixTimeMilliseconds();
    
    public string Id { get; protected set;  } = Guid.NewGuid().ToString("N");
}