using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GalleryController(
    ILogger<GalleryController> logger,
    ApplicationDbContext context
) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Gallery>>> GetAll()
    {
        return Ok(await context.Gallery
            .ToListAsync());
    }

    [HttpGet("categories")]
    public async Task<ActionResult<NavCategories>> GetCategories()
    {
        var galleries = await context.Gallery
            .Select(g => new NavCategories
            {
                Id = g.Id,
                Name = g.Name
            })
            .ToListAsync();
        return Ok(galleries);
    }


    [HttpGet("{id:int}")]
    public async Task<ActionResult<Gallery>> Get(int id)
    {
        var gallery = await context.Gallery
            .FindAsync(id);
        if (gallery == null)
            return NotFound();
        return Ok(gallery);
    }
}