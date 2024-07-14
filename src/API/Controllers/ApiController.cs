using Microsoft.AspNetCore.Mvc;

namespace MyDay.API.Controllers;

[ApiController]
[Route("/api/[controller]")]
public abstract class ApiController : ControllerBase
{
    protected ActionResult<ServiceResponse<bool>> GenerateResponse(ServiceResponse<bool> serviceResponse)
    {
        if (serviceResponse.Success is false)
        {
            return BadRequest(serviceResponse);
        }

        return Ok(serviceResponse);
    }
}