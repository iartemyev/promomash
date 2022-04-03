namespace PromoMash.Domain.Common;

public abstract class PromoMashValueObject : IValueObject
{
    public abstract IEnumerable<object> GetEqualityComponents();

    private bool Equals(PromoMashValueObject other) => GetHashCode() == other.GetHashCode();

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj))
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        return obj.GetType() == GetType() && Equals((PromoMashValueObject)obj);
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Aggregate(1, (current, obj) =>
            {
                unchecked
                {
                    return current * 397 ^ (obj?.GetHashCode() ?? 0);
                }
            });
    }

    public static bool operator ==(PromoMashValueObject first, PromoMashValueObject second) => !(first is null) && !(second is null) && first.Equals(second);

    public static bool operator !=(PromoMashValueObject first, PromoMashValueObject second) => !(first == second);
}