using Application.Features.Carts.Commands.Create;
using Application.Features.Carts.Commands.Delete;
using Application.Features.Carts.Commands.Update;
using Application.Features.Carts.Queries.GetById;
using Application.Features.Carts.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCartCommand createCartCommand)
    {
        CreatedCartResponse response = await Mediator.Send(createCartCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCartCommand updateCartCommand)
    {
        UpdatedCartResponse response = await Mediator.Send(updateCartCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedCartResponse response = await Mediator.Send(new DeleteCartCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdCartResponse response = await Mediator.Send(new GetByIdCartQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCartQuery getListCartQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCartListItemDto> response = await Mediator.Send(getListCartQuery);
        return Ok(response);
    }
}