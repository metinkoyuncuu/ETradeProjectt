using Application.Features.Faqs.Commands.Create;
using Application.Features.Faqs.Commands.Delete;
using Application.Features.Faqs.Commands.Update;
using Application.Features.Faqs.Queries.GetById;
using Application.Features.Faqs.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FaqsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateFaqCommand createFaqCommand)
    {
        CreatedFaqResponse response = await Mediator.Send(createFaqCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateFaqCommand updateFaqCommand)
    {
        UpdatedFaqResponse response = await Mediator.Send(updateFaqCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedFaqResponse response = await Mediator.Send(new DeleteFaqCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdFaqResponse response = await Mediator.Send(new GetByIdFaqQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListFaqQuery getListFaqQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListFaqListItemDto> response = await Mediator.Send(getListFaqQuery);
        return Ok(response);
    }
}