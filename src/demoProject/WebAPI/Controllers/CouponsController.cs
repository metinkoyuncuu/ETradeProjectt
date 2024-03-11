using Application.Features.Coupons.Commands.Create;
using Application.Features.Coupons.Commands.Delete;
using Application.Features.Coupons.Commands.Update;
using Application.Features.Coupons.Queries.GetById;
using Application.Features.Coupons.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CouponsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCouponCommand createCouponCommand)
    {
        CreatedCouponResponse response = await Mediator.Send(createCouponCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCouponCommand updateCouponCommand)
    {
        UpdatedCouponResponse response = await Mediator.Send(updateCouponCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedCouponResponse response = await Mediator.Send(new DeleteCouponCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdCouponResponse response = await Mediator.Send(new GetByIdCouponQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCouponQuery getListCouponQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCouponListItemDto> response = await Mediator.Send(getListCouponQuery);
        return Ok(response);
    }
}