using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using Shared.Realisations;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ManufacturerController(
    ILogger<ManufacturerController> logger,
    ApplicationDbContext context
) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Manufacturer>>> GetAll()
    {
        return Ok(await context.Manufacturers
            .ToListAsync());
    }

    [HttpGet("partners")]
    public async Task<ActionResult<IEnumerable<ManufacturerDto>>> GetPartners()
    {
        return Ok(await context.Manufacturers
            .Where(m => m.IsPartner)
            .Select(m => new ManufacturerDto
            {
                Name = m.Name,
                Description = m.Description,
                Website = m.Website,
                ImageUrl = m.ImageUrl
            })
            .ToListAsync());
    }
}