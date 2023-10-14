using lodging.Schemas;
using lodging.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lodging.Controllers.Reserve;

[ApiController]
[Route("v1")]
public class ShowGuestsController : ControllerBase
{
    [HttpGet]
    [Route("reserve/guests")]
    [Authorize]
    public Task<IActionResult> ShowGuests([FromQuery] ShowGuestsSchema prop)
    {
        var service = new ShowGuestsService();

        var status = service.ShowGuests(prop).Result;

        if (status is false) NotFound("operation not performed");
        
        return Task.FromResult<IActionResult>(Ok(status));
    }
}