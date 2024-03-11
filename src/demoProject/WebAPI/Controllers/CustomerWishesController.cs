using Application.Features.CustomerWishes.Commands.Create;
using Application.Features.CustomerWishes.Commands.Delete;
using Application.Features.CustomerWishes.Commands.Update;
using Application.Features.CustomerWishes.Queries.GetById;
using Application.Features.CustomerWishes.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerWishesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCustomerWishCommand createCustomerWishCommand)
    {
        CreatedCustomerWishResponse response = await Mediator.Send(createCustomerWishCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCustomerWishCommand updateCustomerWishCommand)
    {
        UpdatedCustomerWishResponse response = await Mediator.Send(updateCustomerWishCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedCustomerWishResponse response = await Mediator.Send(new DeleteCustomerWishCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdCustomerWishResponse response = await Mediator.Send(new GetByIdCustomerWishQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCustomerWishQuery getListCustomerWishQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCustomerWishListItemDto> response = await Mediator.Send(getListCustomerWishQuery);
        return Ok(response);
    }
}