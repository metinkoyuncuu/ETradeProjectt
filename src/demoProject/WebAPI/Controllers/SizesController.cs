using Application.Features.Sizes.Commands.Create;
using Application.Features.Sizes.Commands.Delete;
using Application.Features.Sizes.Commands.Update;
using Application.Features.Sizes.Queries.GetById;
using Application.Features.Sizes.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SizesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateSizeCommand createSizeCommand)
    {
        CreatedSizeResponse response = await Mediator.Send(createSizeCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateSizeCommand updateSizeCommand)
    {
        UpdatedSizeResponse response = await Mediator.Send(updateSizeCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedSizeResponse response = await Mediator.Send(new DeleteSizeCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdSizeResponse response = await Mediator.Send(new GetByIdSizeQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSizeQuery getListSizeQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListSizeListItemDto> response = await Mediator.Send(getListSizeQuery);
        return Ok(response);
    }
}