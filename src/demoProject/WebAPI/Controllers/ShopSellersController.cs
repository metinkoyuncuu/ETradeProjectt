using Application.Features.ShopSellers.Commands.Create;
using Application.Features.ShopSellers.Commands.Delete;
using Application.Features.ShopSellers.Commands.Update;
using Application.Features.ShopSellers.Queries.GetById;
using Application.Features.ShopSellers.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShopSellersController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateShopSellerCommand createShopSellerCommand)
    {
        CreatedShopSellerResponse response = await Mediator.Send(createShopSellerCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateShopSellerCommand updateShopSellerCommand)
    {
        UpdatedShopSellerResponse response = await Mediator.Send(updateShopSellerCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedShopSellerResponse response = await Mediator.Send(new DeleteShopSellerCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdShopSellerResponse response = await Mediator.Send(new GetByIdShopSellerQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListShopSellerQuery getListShopSellerQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListShopSellerListItemDto> response = await Mediator.Send(getListShopSellerQuery);
        return Ok(response);
    }
}