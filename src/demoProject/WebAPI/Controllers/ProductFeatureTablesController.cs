using Application.Features.ProductFeatureTables.Commands.Create;
using Application.Features.ProductFeatureTables.Commands.Delete;
using Application.Features.ProductFeatureTables.Commands.Update;
using Application.Features.ProductFeatureTables.Queries.GetById;
using Application.Features.ProductFeatureTables.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductFeatureTablesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProductFeatureTableCommand createProductFeatureTableCommand)
    {
        CreatedProductFeatureTableResponse response = await Mediator.Send(createProductFeatureTableCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProductFeatureTableCommand updateProductFeatureTableCommand)
    {
        UpdatedProductFeatureTableResponse response = await Mediator.Send(updateProductFeatureTableCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedProductFeatureTableResponse response = await Mediator.Send(new DeleteProductFeatureTableCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdProductFeatureTableResponse response = await Mediator.Send(new GetByIdProductFeatureTableQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListProductFeatureTableQuery getListProductFeatureTableQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListProductFeatureTableListItemDto> response = await Mediator.Send(getListProductFeatureTableQuery);
        return Ok(response);
    }
}