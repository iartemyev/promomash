namespace PromoMash.Domain.Common;

public interface IValueObject
{
    IEnumerable<object> GetEqualityComponents();
}