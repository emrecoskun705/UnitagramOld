﻿using Microsoft.AspNetCore.Mvc;
using Unitagram.WebAPI.CustomFilters;

namespace Unitagram.WebAPI.Controllers;

/// <summary>
/// Custom Controller base for API
/// </summary>
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ServiceFilter(typeof(EmailConfirmationFilter))]
public class CustomControllerBase : ControllerBase
{
}