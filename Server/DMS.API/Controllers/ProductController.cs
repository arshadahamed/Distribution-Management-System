using DMS.Application.Features.DTOs;
using DMS.Application.Features.Products.Commands.Create;
using DMS.Application.Features.Products.Commands.Delete;
using DMS.Application.Features.Products.Commands.Update;
using DMS.Application.Features.Products.Queries.GetAllProducts;
using DMS.Application.Features.Products.Queries.GetProductById;
using DMS.Application.Features.Products.Queries.SearchProducts;
using DMS.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

[EnableCors("AllowAll")]
[Authorize]
[ApiController]
[Route("api/products")]
public class ProductController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [Authorize(Roles = "Admin, User")] 
    public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
    {
        var query = new GetAllProductsQuery();
        var products = await mediator.Send(query);
        return Ok(products);
    }


    [HttpGet("{id}")]
    [Authorize(Roles = "Admin,User")]
    public async Task<ActionResult<ProductDto>> GetById([FromRoute] int id)
    {
        var product = await mediator.Send(new GetProductByIdQuery(id));
        return Ok(product);
    }

    [HttpPatch("{id}")]
    [Authorize(Roles = "Admin")] 
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] UpdateProductCommand command)
    {
        command.ProductId = id;

        try
        {
            await mediator.Send(command);
            return NoContent();
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
        catch (ForbidException)
        {
            return Forbid();
        }
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")] 
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteProduct([FromRoute] int id)
    {
        await mediator.Send(new DeleteProductCommand(id));
        return NoContent();
    }

    [HttpPost]
    [Authorize(Roles = "Admin")] 
    public async Task<IActionResult> CreateBook([FromBody] CreateProductCommand command)
    {
        int id = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

    [HttpGet("search")]
    [Authorize(Roles = "Admin,User")]
    public async Task<IActionResult> SearchProduct([FromQuery] string? keywords)
    {
        var query = new SearchProductQuery
        {
            Keywords = keywords
           
        };

        var result = await mediator.Send(query);
        return Ok(result);
    }
}
