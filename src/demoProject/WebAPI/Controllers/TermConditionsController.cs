using Application.Features.TermConditions.Commands.Create;
using Application.Features.TermConditions.Commands.Delete;
using Application.Features.TermConditions.Commands.Update;
using Application.Features.TermConditions.Queries.GetById;
using Application.Features.TermConditions.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TermConditionsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateTermConditionCommand createTermConditionCommand)
    {
        CreatedTermConditionResponse response = await Mediator.Send(createTermConditionCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateTermConditionCommand updateTermConditionCommand)
    {
        UpdatedTermConditionResponse response = await Mediator.Send(updateTermConditionCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedTermConditionResponse response = await Mediator.Send(new DeleteTermConditionCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdTermConditionResponse response = await Mediator.Send(new GetByIdTermConditionQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListTermConditionQuery getListTermConditionQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListTermConditionListItemDto> response = await Mediator.Send(getListTermConditionQuery);
        return Ok(response);
    }
}