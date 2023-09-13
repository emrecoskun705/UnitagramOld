using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text.Encodings.Web;
using MediatR;
using Unitagram.Application.Features.University.Queries.GetUniversityByDomain;

namespace Unitagram.WebAPI.Controllers.v1;

/// <summary>
/// 
/// </summary>
[ApiVersion("1.0")]
public class UniversityController : CustomControllerBase
{
    private readonly IMediator _mediator;
        
    /// <summary>
    /// 
    /// </summary>
    /// <param name="mediator"></param>
    public UniversityController(IMediator mediator)
    {
        _mediator = mediator;
    }
        

    /// <summary>
    /// 
    /// </summary>
    /// <param name="domain"></param>
    /// <returns></returns>
    [HttpGet("get")]
    public async Task<IActionResult> GetUniversityByDomain(string domain)
    {

        var university = await _mediator.Send(new GetUniversityByDomainQuery(domain));
        
        return Ok(university);
    }
}