using lodging.Schemas;
using lodging.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lodging.Controllers;

[ApiController]
[Route("v1")]
public class DeleteReserveController : ControllerBase
{
    [HttpDelete]
    [Route("reserve/delete")]
    [Authorize]
    public async Task<IActionResult> DeleteReserve([FromBody] DeleteReserveSchema reserve)
    {
        var service = new DeleteReserveSchemaService();

        var status = service.DeleteReserve(reserve).Result;

        if (!status) return BadRequest("operation not performed");

        return Ok($"operation carried out successfully");
    }
}