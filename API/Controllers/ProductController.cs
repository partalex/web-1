using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Models;
using Shared.Realisations;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController(
    ILogger<ProductController> logger,
    ApplicationDbContext context
) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductShortDto>>> GetAll()
    {
        var products = await context.Products
            .Where(p => p.Available)
            .Select(p => new ProductShortDto
            {
                Name = p.Name,
                ImageUrl = p.ImageUrl,
                Description = p.Description ?? "",
            })
            .ToListAsync();
        return Ok(products);
    }

    [HttpGet("categories")]
    public async Task<ActionResult<IEnumerable<NavCategories>>> GetCategories()
    {
        var data = await context.Products
            .Where(p => p.Available)
            .Select(p => new NavCategories
            {
                Id = p.Id,
                Name = p.Name
            })
            .ToListAsync();
        return Ok(data);
    }


    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductDetailDto>> Get(int id)
    {
        var product = await context.Products
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
            return NotFound($"Product with id {id} not found.");

        var options = await context.ProductOptions
            .Where(o => product.Options.Contains(o.Id))
            .ToListAsync();

        var productDto = new ProductDetailDto
        {
            Name = product.Name,
            ImageUrl = product.ImageUrl,
            Description = product.Description ?? "",
            Options = options.Select(o => new ProductOptionDto
            {
                Name = o.Name,
                Options = o.Options.Split(ProductOptionDto.Delimiter).ToList()
            }).ToList(),
        };

        return Ok(productDto);
    }
}