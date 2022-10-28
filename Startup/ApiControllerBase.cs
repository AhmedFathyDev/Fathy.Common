using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fathy.Startup;

[ApiController]
[Route("api/[controller]/[action]")]
public class ApiControllerBase : ControllerBase
{
    protected IActionResult ResponseToIActionResult(Response response)
    {
        if (response.Succeeded) return Ok();

        if (response.Errors!.Any(x => x.StatusCode == StatusCodes.Status404NotFound))
            return NotFound(response.Errors.ToJsonStringContent());

        return BadRequest(response.Errors.ToJsonStringContent());
    }

    protected IActionResult ResponseToIActionResult<T>(Response<T> response)
    {
        if (response.Succeeded) return Ok(response.Data.ToJsonStringContent());

        if (response.Errors!.Any(x => x.StatusCode == StatusCodes.Status404NotFound))
            return NotFound(response.Errors.ToJsonStringContent());

        return BadRequest(response.Errors.ToJsonStringContent());
    }
}