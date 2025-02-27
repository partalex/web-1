using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using Shared.Realisations;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemController(
    ILogger<ItemController> logger,
    ApplicationDbContext context
) : ControllerBase

{
    [HttpGet]
    public async Task<ActionResult<List<ItemDto>>> GetAll()
    {
        var items = await context.ItemTags
            .Include(io => io.Tag)
            .GroupBy(io => io.ItemId)
            .Select(g => new ItemDto
            {
                Id = g.Key,
                Tags = g.Select(io => new TagsDto
                {
                    TagId = io.TagId,
                    Value = io.Value
                }).ToList()
            })
            .ToListAsync();

        return Ok(items);
    }

    [HttpGet("container")]
    public async Task<ActionResult<Container<ItemDto>>> GetContainer()
    {
        var itemTags = await context.ItemTags
            .Include(io => io.Tag)
            .ThenInclude(t => t.Filter)
            .ToListAsync();

        var items = itemTags
            .GroupBy(io => io.ItemId)
            .Select(g => new ItemDto
            {
                Id = g.Key,
                Tags = g.Select(io => new TagsDto
                {
                    TagId = io.TagId,
                    Value = io.Value
                }).ToList()
            })
            .ToList();

        var filters = itemTags
            .Where(io => io.Tag?.FilterId != (int)FilterType.Image && io.Tag?.FilterId != (int)FilterType.NoFiltering)
            .GroupBy(io => io.TagId)
            .Select(g => new FilterDto
            {
                TagId = g.Key,
                Values = g
                    .SelectMany(io => io.Tag!.Filter != null && io.Tag.Filter.StringFalseListTrue
                        ? io.Value.Split(Filter.Delimiter)
                        : [io.Value])
                    .Distinct()
                    .OrderBy(value => value)
                    .ToList(),
                Name = g.First().Tag!.Name,
                FilterType = (FilterType)g.First().Tag!.FilterId
            })
            .ToList();

        var itemGallery = new Container<ItemDto>
        {
            Filters = filters,
            Items = items
        };

        return Ok(itemGallery);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ItemDto>> Get(int id)
    {
        var itemOptions = await context.ItemTags
            .Where(d => d.ItemId == id)
            .Include(io => io.Tag)
            .ToListAsync();

        if (itemOptions.Count == 0)
            return NotFound($"Item with id {id} not found.");

        var itemDto = new ItemDto
        {
            Id = id,
            Tags = itemOptions.Select(io => new TagsDto
            {
                TagId = io.TagId,
                Value = io.Value
            }).ToList()
        };

        return Ok(itemDto);
    }
}