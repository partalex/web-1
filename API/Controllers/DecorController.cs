using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using Shared.Realisations;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DecorController(
    ILogger<DecorController> logger,
    ApplicationDbContext context
) : ControllerBase
{
    private const int ManufacturerMaterialId = 1;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DecorDto>>> GetAll()
    {
        var data = await context.Decors
            .OrderBy(x => x.Purposes[0])
            .Select(x => new DecorDto
            {
                Name = x.Name,
                ImageUrl = x.ImageUrl
            })
            // .Take(10)
            .ToListAsync();
        return Ok(data);
    }

    [HttpPost("filter")]
    public async Task<ActionResult<IEnumerable<DecorDto>>> Filter([FromBody] FilterParamsDecor filterParams)
    {
        IQueryable<Decor> query = context.Decors;

        if (!string.IsNullOrEmpty(filterParams.Name))
            query = query.Where(d => d.Name.Contains(filterParams.Name));

        if (filterParams.Materials != null && filterParams.Materials.Count != 0)
            query = query.Where(d => d.Materials.Any(m => filterParams.Materials.Contains(m)));

        if (filterParams.Purposes != null && filterParams.Purposes.Count != 0)
            query = query.Where(d => d.Purposes.Any(p => filterParams.Purposes.Contains(p)));

        if (filterParams.Colors != null && filterParams.Colors.Count != 0)
            query = query.Where(d => d.Colors.Any(c => filterParams.Colors.Contains(c)));

        if (filterParams.Reflections != null && filterParams.Reflections.Count != 0)
            query = query.Where(d => d.Reflections.Any(r => filterParams.Reflections.Contains(r)));

        if (filterParams.Patterns != null && filterParams.Patterns.Count != 0)
            query = query.Where(d => d.Patterns.Any(p => filterParams.Patterns.Contains(p)));

        if (filterParams.Manufacturers != null && filterParams.Manufacturers.Count != 0)
            query = query.Where(d => d.ManufacturerId == filterParams.Manufacturers[0]);

        var data = await query
            .Select(x => new DecorDto
            {
                Name = x.Name,
                ImageUrl = x.ImageUrl
            })
            .ToListAsync();

        return Ok(data);
    }

    [HttpGet("filters")]
    public async Task<ActionResult<FilterDecor>> GetFilters()
    {
        var filterDecor = new FilterDecor
        {
            Materials =
            {
                Options = await context.DecorMaterials.OrderBy(x => x.Name).Select(x => new FilterOption(x.Id, x.Name))
                    .ToListAsync()
            },
            Purposes =
            {
                Options = await context.DecorPurposes.OrderBy(x => x.Name).Select(x => new FilterOption(x.Id, x.Name))
                    .ToListAsync()
            },
            Colors =
            {
                Options = await context.DecorColors.OrderBy(x => x.Name).Select(x => new FilterOption(x.Id, x.Name))
                    .ToListAsync()
            },
            Reflections =
            {
                Options = await context.DecorReflections.OrderBy(x => x.Name)
                    .Select(x => new FilterOption(x.Id, x.Name)).ToListAsync()
            },
            Patterns =
            {
                Options = await context.DecorPatterns.OrderBy(x => x.Name).Select(x => new FilterOption(x.Id, x.Name))
                    .ToListAsync()
            },
            Manufacturers =
            {
                Options = await context.Manufacturers.Where(x => x.Activities.Contains(ManufacturerMaterialId)).OrderBy(x => x.Name)
                    .Select(x => new FilterOption(x.Id, x.Name)).ToListAsync()
            }
        };

        return Ok(filterDecor);
    }
}