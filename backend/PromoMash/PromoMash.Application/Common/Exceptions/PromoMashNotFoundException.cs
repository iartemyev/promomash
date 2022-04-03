namespace PromoMash.Application.Common.Exceptions;

public class PromoMashNotFoundException : Exception
{
    public PromoMashNotFoundException(string name, object key) : base($"Entity \"{name}\" ({key}) not found")
    {
        
    }
}