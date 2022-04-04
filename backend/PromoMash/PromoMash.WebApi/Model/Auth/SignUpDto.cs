namespace PromoMash.WebApi.Model.Auth;

public class SignUpDto
{
    public string Login { get; set; }
    
    public string Password { get; set; }
    
    public string CountryId { get; set; }
    
    public string ProvinceId { get; set; }
}