using lodging.Schemas.Person;
using lodging.Services.Person;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lodging.Controllers.Person;

[ApiController]
[Route("v1")]
public class UpdatePersonController : ControllerBase
{
    [HttpPut]
    [Route("user/update")]
    [Authorize]
    public Task<IActionResult> UpdatePerson(UpdatePersonSchema prop)
    {
        var service = new UpdatePersonServices();
        var status = service.UpdatePerson(prop).Result;
        
        if (!status) return Task.FromResult<IActionResult>(BadRequest("operation not performed"));

        return Task.FromResult<IActionResult>(Ok($"operation carried out successfully"));
    }
}