using lodging.Schemas;
using lodging.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lodging.Controllers;

[ApiController]
[Route("v1")]
public class LoginController : ControllerBase
{
    [HttpPost]
    [Route("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginSchema prop)
    {
        var service = new LoginServices();

        var status = service.GetToken(prop);

        if (status is null) return NotFound("operation not performed");

        return Ok(status);
    }
}