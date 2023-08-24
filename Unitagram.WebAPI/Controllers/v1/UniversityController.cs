using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Unitagram.Core.Domain.Entities;
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
            University test = new University()
            {
                Domain = "dsafds",
                Name = "sdfsd",
                Province = "dsfsdfds",
            };

            _context.University.Add(test);

            _context.SaveChanges();
            return Ok();
        }
    }
}
