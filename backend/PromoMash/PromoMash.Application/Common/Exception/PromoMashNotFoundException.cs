namespace PromoMash.Application.Common.Exception;

public class PromoMashNotFoundException : System.Exception
{
    public PromoMashNotFoundException(string name, object key) : base($"Entity \"{name}\" ({key}) not found")
    {
        
    }
}