using Application.Features.Genders.Commands.Create;
using Application.Features.Genders.Commands.Delete;
using Application.Features.Genders.Commands.Update;
using Application.Features.Genders.Queries.GetById;
using Application.Features.Genders.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GendersController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateGenderCommand createGenderCommand)
    {
        CreatedGenderResponse response = await Mediator.Send(createGenderCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateGenderCommand updateGenderCommand)
    {
        UpdatedGenderResponse response = await Mediator.Send(updateGenderCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedGenderResponse response = await Mediator.Send(new DeleteGenderCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdGenderResponse response = await Mediator.Send(new GetByIdGenderQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListGenderQuery getListGenderQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListGenderListItemDto> response = await Mediator.Send(getListGenderQuery);
        return Ok(response);
    }
}