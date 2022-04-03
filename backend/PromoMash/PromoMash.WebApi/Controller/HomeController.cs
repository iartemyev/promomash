using Microsoft.AspNetCore.Mvc;

namespace PromoMash.WebApi.Controller;

//[OpenApiIgnore]
[Route("/")]
public class HomeController : ControllerBase
{
    [HttpGet]
    [ProducesDefaultResponseType]
    public ActionResult Index()
    {
        return Redirect("/swagger");
    }
}