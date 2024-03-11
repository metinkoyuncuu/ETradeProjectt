using Application.Features.CustomerOrders.Commands.Create;
using Application.Features.CustomerOrders.Commands.Delete;
using Application.Features.CustomerOrders.Commands.Update;
using Application.Features.CustomerOrders.Queries.GetById;
using Application.Features.CustomerOrders.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerOrdersController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCustomerOrderCommand createCustomerOrderCommand)
    {
        CreatedCustomerOrderResponse response = await Mediator.Send(createCustomerOrderCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCustomerOrderCommand updateCustomerOrderCommand)
    {
        UpdatedCustomerOrderResponse response = await Mediator.Send(updateCustomerOrderCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedCustomerOrderResponse response = await Mediator.Send(new DeleteCustomerOrderCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdCustomerOrderResponse response = await Mediator.Send(new GetByIdCustomerOrderQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCustomerOrderQuery getListCustomerOrderQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCustomerOrderListItemDto> response = await Mediator.Send(getListCustomerOrderQuery);
        return Ok(response);
    }
}