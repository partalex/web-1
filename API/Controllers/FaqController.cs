using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FaqController(ILogger<FaqController> logger, ApplicationDbContext context) : ControllerBase
{
    [HttpGet("available")]
    public async Task<ActionResult<IEnumerable<Faq>>> GetAnswered()
    {
        var data = await context.Faqs
            .Where(f => f.Available)
            .ToListAsync();
        return Ok(data);
    }

    [HttpPost]
    public async Task<ActionResult<Faq>> Post(Faq data)
    {
        context.Faqs.Add(data);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAnswered), new { id = data.Id }, data);
    }
}