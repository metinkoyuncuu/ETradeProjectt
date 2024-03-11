using Application.Features.CustomerCoupons.Commands.Create;
using Application.Features.CustomerCoupons.Commands.Delete;
using Application.Features.CustomerCoupons.Commands.Update;
using Application.Features.CustomerCoupons.Queries.GetById;
using Application.Features.CustomerCoupons.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerCouponsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCustomerCouponCommand createCustomerCouponCommand)
    {
        CreatedCustomerCouponResponse response = await Mediator.Send(createCustomerCouponCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCustomerCouponCommand updateCustomerCouponCommand)
    {
        UpdatedCustomerCouponResponse response = await Mediator.Send(updateCustomerCouponCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedCustomerCouponResponse response = await Mediator.Send(new DeleteCustomerCouponCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdCustomerCouponResponse response = await Mediator.Send(new GetByIdCustomerCouponQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCustomerCouponQuery getListCustomerCouponQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCustomerCouponListItemDto> response = await Mediator.Send(getListCustomerCouponQuery);
        return Ok(response);
    }
}