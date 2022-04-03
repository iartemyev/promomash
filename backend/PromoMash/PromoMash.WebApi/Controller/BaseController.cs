using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PromoMash.WebApi.Controller;

[ApiController]
[Route("api/[controller]/[action]")]
public class BaseController : HomeController
{
    private IMediator _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>()!;
    
    protected IActionResult Created(object value = null)
    {
        return StatusCode(StatusCodes.Status201Created, value);
    }
    
    protected IActionResult InternalError(object value = null)
    {
        return StatusCode(StatusCodes.Status500InternalServerError, value);
    }
}