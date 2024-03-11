using Application.Features.Cashbacks.Commands.Create;
using Application.Features.Cashbacks.Commands.Delete;
using Application.Features.Cashbacks.Commands.Update;
using Application.Features.Cashbacks.Queries.GetById;
using Application.Features.Cashbacks.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CashbacksController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCashbackCommand createCashbackCommand)
    {
        CreatedCashbackResponse response = await Mediator.Send(createCashbackCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCashbackCommand updateCashbackCommand)
    {
        UpdatedCashbackResponse response = await Mediator.Send(updateCashbackCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedCashbackResponse response = await Mediator.Send(new DeleteCashbackCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdCashbackResponse response = await Mediator.Send(new GetByIdCashbackQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCashbackQuery getListCashbackQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCashbackListItemDto> response = await Mediator.Send(getListCashbackQuery);
        return Ok(response);
    }
}