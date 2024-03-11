using Application.Features.Shippings.Commands.Create;
using Application.Features.Shippings.Commands.Delete;
using Application.Features.Shippings.Commands.Update;
using Application.Features.Shippings.Queries.GetById;
using Application.Features.Shippings.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShippingsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateShippingCommand createShippingCommand)
    {
        CreatedShippingResponse response = await Mediator.Send(createShippingCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateShippingCommand updateShippingCommand)
    {
        UpdatedShippingResponse response = await Mediator.Send(updateShippingCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedShippingResponse response = await Mediator.Send(new DeleteShippingCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdShippingResponse response = await Mediator.Send(new GetByIdShippingQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListShippingQuery getListShippingQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListShippingListItemDto> response = await Mediator.Send(getListShippingQuery);
        return Ok(response);
    }
}