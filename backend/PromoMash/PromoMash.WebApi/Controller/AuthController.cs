using Microsoft.AspNetCore.Mvc;
using PromoMash.WebApi.Model.Auth;

namespace PromoMash.WebApi.Controller;

public class AuthController : BaseController
{
    [HttpPost]
    public Task<IActionResult> SignUp([FromBody] SignUpDto dto)
    {
        return Task.FromResult(Created(Guid.NewGuid().ToString("N")));
    }
}