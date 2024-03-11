using Application.Features.ProductFeatures.Commands.Create;
using Application.Features.ProductFeatures.Commands.Delete;
using Application.Features.ProductFeatures.Commands.Update;
using Application.Features.ProductFeatures.Queries.GetById;
using Application.Features.ProductFeatures.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductFeaturesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProductFeatureCommand createProductFeatureCommand)
    {
        CreatedProductFeatureResponse response = await Mediator.Send(createProductFeatureCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProductFeatureCommand updateProductFeatureCommand)
    {
        UpdatedProductFeatureResponse response = await Mediator.Send(updateProductFeatureCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedProductFeatureResponse response = await Mediator.Send(new DeleteProductFeatureCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdProductFeatureResponse response = await Mediator.Send(new GetByIdProductFeatureQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListProductFeatureQuery getListProductFeatureQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListProductFeatureListItemDto> response = await Mediator.Send(getListProductFeatureQuery);
        return Ok(response);
    }
}