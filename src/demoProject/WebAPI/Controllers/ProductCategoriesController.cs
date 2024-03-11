using Application.Features.ProductCategories.Commands.Create;
using Application.Features.ProductCategories.Commands.Delete;
using Application.Features.ProductCategories.Commands.Update;
using Application.Features.ProductCategories.Queries.GetById;
using Application.Features.ProductCategories.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductCategoriesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProductCategoryCommand createProductCategoryCommand)
    {
        CreatedProductCategoryResponse response = await Mediator.Send(createProductCategoryCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProductCategoryCommand updateProductCategoryCommand)
    {
        UpdatedProductCategoryResponse response = await Mediator.Send(updateProductCategoryCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedProductCategoryResponse response = await Mediator.Send(new DeleteProductCategoryCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdProductCategoryResponse response = await Mediator.Send(new GetByIdProductCategoryQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListProductCategoryQuery getListProductCategoryQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListProductCategoryListItemDto> response = await Mediator.Send(getListProductCategoryQuery);
        return Ok(response);
    }
}