using lodging.Schemas;
using lodging.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lodging.Controllers;

[ApiController]
[Route("v1")]
public class NewReserveController : ControllerBase
{
    [HttpPost]
    [Route("reserve/add")]
    [Authorize]
    public async Task<IActionResult> NewReserve(ReserveSchema prop)
    {
        var service = new NewReserveService();

        var status = service.NewRerseve(prop).Result;

        if (!status) return BadRequest("operation not performed");

        return Ok(status);
    }
    
}