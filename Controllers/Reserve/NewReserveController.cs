using lodging.Schemas.Reserve;
using lodging.Services.Reserve;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lodging.Controllers.Reserve;

[ApiController]
[Route("v1")]
public class NewReserveController : ControllerBase
{
    [HttpPost]
    [Route("reserve/add")]
    [Authorize]
    public Task<IActionResult> NewReserve(ReserveSchema prop)
    {
        var service = new NewReserveService();

        var status = service.NewRerseve(prop).Result;

        if (!status) return Task.FromResult<IActionResult>(BadRequest("operation not performed"));

        return Task.FromResult<IActionResult>(Ok(status));
    }
    
}