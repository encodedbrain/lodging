using lodging.Schemas;
using lodging.Services;
using lodging.Services.Reserve;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lodging.Controllers.Reserve;

[ApiController]
[Route("v1")]
public class ReserveController : ControllerBase
{
    [HttpPost]
    [Route("reserve")]
    [AllowAnonymous]
    public Task<IActionResult> Reserve([FromBody] ReservationSchema prop)
    {
        var service = new ReservationService();

        var status = service.Reservation(prop).Result;

        if (status is false) NotFound("operation not performed");

        return Task.FromResult<IActionResult>(Ok(status));
    }
}
        