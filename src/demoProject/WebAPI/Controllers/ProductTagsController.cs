using Application.Features.ProductTags.Commands.Create;
using Application.Features.ProductTags.Commands.Delete;
using Application.Features.ProductTags.Commands.Update;
using Application.Features.ProductTags.Queries.GetById;
using Application.Features.ProductTags.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductTagsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProductTagCommand createProductTagCommand)
    {
        CreatedProductTagResponse response = await Mediator.Send(createProductTagCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProductTagCommand updateProductTagCommand)
    {
        UpdatedProductTagResponse response = await Mediator.Send(updateProductTagCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedProductTagResponse response = await Mediator.Send(new DeleteProductTagCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdProductTagResponse response = await Mediator.Send(new GetByIdProductTagQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListProductTagQuery getListProductTagQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListProductTagListItemDto> response = await Mediator.Send(getListProductTagQuery);
        return Ok(response);
    }
}