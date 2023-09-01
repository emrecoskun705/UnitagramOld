using Microsoft.AspNetCore.Mvc;

namespace Unitagram.WebAPI.Controllers
{
    /// <summary>
    /// Custom Controller base for API
    /// </summary>
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CustomControllerBase : ControllerBase
    {
    }
}
