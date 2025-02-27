using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServiceController(
    ILogger<ServiceController> logger,
    ApplicationDbContext context
) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Service>>> GetAll()
    {
        return Ok(await context.Services
            .ToListAsync());
    }

    [HttpGet("available")]
    public async Task<ActionResult<IEnumerable<Service>>> GetAvailable()
    {
        return Ok(await context.Services
            .Where(x => x.Available)
            .ToListAsync());
    }

    [HttpGet("featured")]
    public async Task<ActionResult<IEnumerable<Service>>> GetFeatured()
    {
        return Ok(await context.Services
            .Where(x => x.Featured && x.Available)
            .ToListAsync());
    }
}