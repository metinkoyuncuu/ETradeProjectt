using Application.Features.Logs.Commands.Create;
using Application.Features.Logs.Commands.Delete;
using Application.Features.Logs.Commands.Update;
using Application.Features.Logs.Queries.GetById;
using Application.Features.Logs.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LogsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateLogCommand createLogCommand)
    {
        CreatedLogResponse response = await Mediator.Send(createLogCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateLogCommand updateLogCommand)
    {
        UpdatedLogResponse response = await Mediator.Send(updateLogCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedLogResponse response = await Mediator.Send(new DeleteLogCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdLogResponse response = await Mediator.Send(new GetByIdLogQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListLogQuery getListLogQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListLogListItemDto> response = await Mediator.Send(getListLogQuery);
        return Ok(response);
    }
}