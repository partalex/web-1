using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Realisations;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DecorPurposeController(
    ILogger<UserController> logger,
    ApplicationDbContext context
) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PurposeDto>>> GetAll()
    {
        return Ok(await context.DecorPurposes.Select(p => new PurposeDto
            {
                Id = p.Id,
                Name = p.Name
            })
            .ToListAsync());
    }
}