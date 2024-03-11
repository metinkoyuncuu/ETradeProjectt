using Application.Features.Bills.Commands.Create;
using Application.Features.Bills.Commands.Delete;
using Application.Features.Bills.Commands.Update;
using Application.Features.Bills.Queries.GetById;
using Application.Features.Bills.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BillsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBillCommand createBillCommand)
    {
        CreatedBillResponse response = await Mediator.Send(createBillCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBillCommand updateBillCommand)
    {
        UpdatedBillResponse response = await Mediator.Send(updateBillCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedBillResponse response = await Mediator.Send(new DeleteBillCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdBillResponse response = await Mediator.Send(new GetByIdBillQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBillQuery getListBillQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListBillListItemDto> response = await Mediator.Send(getListBillQuery);
        return Ok(response);
    }
}