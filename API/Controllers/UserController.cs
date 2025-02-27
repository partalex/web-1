using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(
    ILogger<UserController> logger,
    ApplicationDbContext context
) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetAll()
    {
        return Ok(await context.Users
            .ToListAsync());
    }

    // [Authorize]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<User>> Get(int id)
    {
        var data = await context.Users
            .FirstOrDefaultAsync(u => u.Id == id);
        if (data == null)
            return NotFound($"User with id {id} not found.");
        return Ok(data);
    }
}