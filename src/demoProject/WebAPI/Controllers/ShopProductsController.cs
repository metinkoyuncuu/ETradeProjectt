using Application.Features.ShopProducts.Commands.Create;
using Application.Features.ShopProducts.Commands.Delete;
using Application.Features.ShopProducts.Commands.Update;
using Application.Features.ShopProducts.Queries.GetById;
using Application.Features.ShopProducts.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShopProductsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateShopProductCommand createShopProductCommand)
    {
        CreatedShopProductResponse response = await Mediator.Send(createShopProductCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateShopProductCommand updateShopProductCommand)
    {
        UpdatedShopProductResponse response = await Mediator.Send(updateShopProductCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedShopProductResponse response = await Mediator.Send(new DeleteShopProductCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdShopProductResponse response = await Mediator.Send(new GetByIdShopProductQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListShopProductQuery getListShopProductQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListShopProductListItemDto> response = await Mediator.Send(getListShopProductQuery);
        return Ok(response);
    }
}