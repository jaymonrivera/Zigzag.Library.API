using Microsoft.AspNetCore.Mvc;
using Zigzag.Library.API.Interfaces;

namespace Zigzag.Library.API.Controllers;

public abstract class ZigzagBaseController : ControllerBase
{
    protected ActionResult CreateApiResponse<T>(IZigzagRepository repository, T result)
    { 
        return repository.HasError ? BadRequest(repository.Error) : Ok(result);
    }
}
