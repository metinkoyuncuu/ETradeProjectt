using Application.Features.ShopCoupons.Commands.Create;
using Application.Features.ShopCoupons.Commands.Delete;
using Application.Features.ShopCoupons.Commands.Update;
using Application.Features.ShopCoupons.Queries.GetById;
using Application.Features.ShopCoupons.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShopCouponsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateShopCouponCommand createShopCouponCommand)
    {
        CreatedShopCouponResponse response = await Mediator.Send(createShopCouponCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateShopCouponCommand updateShopCouponCommand)
    {
        UpdatedShopCouponResponse response = await Mediator.Send(updateShopCouponCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedShopCouponResponse response = await Mediator.Send(new DeleteShopCouponCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdShopCouponResponse response = await Mediator.Send(new GetByIdShopCouponQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListShopCouponQuery getListShopCouponQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListShopCouponListItemDto> response = await Mediator.Send(getListShopCouponQuery);
        return Ok(response);
    }
}