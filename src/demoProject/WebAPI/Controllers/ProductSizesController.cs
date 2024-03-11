using Application.Features.ProductSizes.Commands.Create;
using Application.Features.ProductSizes.Commands.Delete;
using Application.Features.ProductSizes.Commands.Update;
using Application.Features.ProductSizes.Queries.GetById;
using Application.Features.ProductSizes.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductSizesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProductSizeCommand createProductSizeCommand)
    {
        CreatedProductSizeResponse response = await Mediator.Send(createProductSizeCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProductSizeCommand updateProductSizeCommand)
    {
        UpdatedProductSizeResponse response = await Mediator.Send(updateProductSizeCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedProductSizeResponse response = await Mediator.Send(new DeleteProductSizeCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdProductSizeResponse response = await Mediator.Send(new GetByIdProductSizeQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListProductSizeQuery getListProductSizeQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListProductSizeListItemDto> response = await Mediator.Send(getListProductSizeQuery);
        return Ok(response);
    }
}