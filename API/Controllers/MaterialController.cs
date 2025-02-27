using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Realisations;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MaterialController(
    ILogger<UserController> logger,
    ApplicationDbContext context
) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MaterialDto>>> GetAll()
    {
        return Ok(await context.DecorMaterials
            .Select(m => new MaterialDto
            {
                Id = m.Id,
                Name = m.Name,
                })
            .ToListAsync()
        );
    }
}