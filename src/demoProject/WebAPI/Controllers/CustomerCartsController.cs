using Application.Features.CustomerCarts.Commands.Create;
using Application.Features.CustomerCarts.Commands.Delete;
using Application.Features.CustomerCarts.Commands.Update;
using Application.Features.CustomerCarts.Queries.GetById;
using Application.Features.CustomerCarts.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerCartsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCustomerCartCommand createCustomerCartCommand)
    {
        CreatedCustomerCartResponse response = await Mediator.Send(createCustomerCartCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCustomerCartCommand updateCustomerCartCommand)
    {
        UpdatedCustomerCartResponse response = await Mediator.Send(updateCustomerCartCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedCustomerCartResponse response = await Mediator.Send(new DeleteCustomerCartCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdCustomerCartResponse response = await Mediator.Send(new GetByIdCustomerCartQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCustomerCartQuery getListCustomerCartQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCustomerCartListItemDto> response = await Mediator.Send(getListCustomerCartQuery);
        return Ok(response);
    }
}