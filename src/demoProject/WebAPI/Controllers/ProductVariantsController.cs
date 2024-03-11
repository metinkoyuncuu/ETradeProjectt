using Application.Features.ProductVariants.Commands.Create;
using Application.Features.ProductVariants.Commands.Delete;
using Application.Features.ProductVariants.Commands.Update;
using Application.Features.ProductVariants.Queries.GetById;
using Application.Features.ProductVariants.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductVariantsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProductVariantCommand createProductVariantCommand)
    {
        CreatedProductVariantResponse response = await Mediator.Send(createProductVariantCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProductVariantCommand updateProductVariantCommand)
    {
        UpdatedProductVariantResponse response = await Mediator.Send(updateProductVariantCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedProductVariantResponse response = await Mediator.Send(new DeleteProductVariantCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdProductVariantResponse response = await Mediator.Send(new GetByIdProductVariantQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListProductVariantQuery getListProductVariantQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListProductVariantListItemDto> response = await Mediator.Send(getListProductVariantQuery);
        return Ok(response);
    }
}