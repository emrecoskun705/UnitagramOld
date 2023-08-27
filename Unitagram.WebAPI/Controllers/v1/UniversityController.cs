using Microsoft.AspNetCore.Mvc;
using Unitagram.Infrastructure.DatabaseContext;

namespace Unitagram.WebAPI.Controllers.v1
{
    /// <summary>
    /// 
    /// </summary>
    [ApiVersion("1.0")]
    public class UniversityController : CustomControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UniversityController(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        
        [HttpPost("create")]
        public async Task<IActionResult> PostUniversity()
        {

            return Ok();
        }
    }
}
