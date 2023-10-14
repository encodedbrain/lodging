using lodging.Schemas;
using lodging.Schemas.Person;
using lodging.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lodging.Controllers.Person;

[ApiController]
[Route("v1")]
public class LoginController : ControllerBase
{
    [HttpPost]
    [Route("login")]
    [AllowAnonymous]
    public Task<IActionResult> Login([FromBody] LoginSchema prop)
    {
        var service = new LoginServices();

        var status = service.GetToken(prop);

        if (status is false) return Task.FromResult<IActionResult>(NotFound("operation not performed"));

        return Task.FromResult<IActionResult>(Ok(status));
    }
}