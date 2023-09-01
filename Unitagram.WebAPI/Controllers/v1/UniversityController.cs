using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text.Encodings.Web;

namespace Unitagram.WebAPI.Controllers.v1
{
    /// <summary>
    /// 
    /// </summary>
    [ApiVersion("1.0")]
    public class UniversityController : CustomControllerBase
    {
        // private readonly IUniversityGetterService _universityGetterService;
        //
        // /// <summary>
        // /// 
        // /// </summary>
        // /// <param name="universityGetterService"></param>
        // public UniversityController(IUniversityGetterService universityGetterService)
        // {
        //     _universityGetterService = universityGetterService;
        // }
        //
        //
        // [HttpGet("get")]
        // [AllowAnonymous]
        // public async Task<IActionResult> GetUniversity(string email)
        // {
        //
        //     var university = await _universityGetterService.GetUniversityByEmail(email);
        //
        //     return Ok(university);
        // }
    }
}
