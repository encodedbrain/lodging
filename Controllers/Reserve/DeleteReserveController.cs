using lodging.Schemas;
using lodging.Schemas.Reserve;
using lodging.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lodging.Controllers.Reserve;

[ApiController]
[Route("v1")]
public class DeleteReserveController : ControllerBase
{
    [HttpDelete]
    [Route("reserve/delete")]
    [Authorize]
    public Task<IActionResult> DeleteReserve([FromBody] DeleteReserveSchema reserve)
    {
        var service = new DeleteReserveSchemaService();

        var status = service.DeleteReserve(reserve).Result;

        if (!status) return Task.FromResult<IActionResult>(BadRequest("operation not performed"));

        return Task.FromResult<IActionResult>(Ok($"operation carried out successfully"));
    }
}