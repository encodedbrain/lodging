using lodging.Schemas;
using lodging.Schemas.Reserve;
using lodging.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lodging.Controllers;


[ApiController]
[Route("V1")]
public class CalculateDailyController : ControllerBase
{
    [HttpGet]
    [Route("reserve/daily")]
    [Authorize]
    public Task<IActionResult> CalculateDaily([FromQuery]CalculateDailySchema prop)
    {
        var service = new CalculateDailyService();

        var status = service.CalculateDaily(prop).Result;
        
        if (status is false) return Task.FromResult<IActionResult>(BadRequest("operation not performed"));

        return Task.FromResult<IActionResult>(Ok(status));
    }
}