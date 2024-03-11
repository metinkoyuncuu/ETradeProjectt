using Application.Features.CustomerCompares.Commands.Create;
using Application.Features.CustomerCompares.Commands.Delete;
using Application.Features.CustomerCompares.Commands.Update;
using Application.Features.CustomerCompares.Queries.GetById;
using Application.Features.CustomerCompares.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerComparesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCustomerCompareCommand createCustomerCompareCommand)
    {
        CreatedCustomerCompareResponse response = await Mediator.Send(createCustomerCompareCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCustomerCompareCommand updateCustomerCompareCommand)
    {
        UpdatedCustomerCompareResponse response = await Mediator.Send(updateCustomerCompareCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedCustomerCompareResponse response = await Mediator.Send(new DeleteCustomerCompareCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdCustomerCompareResponse response = await Mediator.Send(new GetByIdCustomerCompareQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCustomerCompareQuery getListCustomerCompareQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCustomerCompareListItemDto> response = await Mediator.Send(getListCustomerCompareQuery);
        return Ok(response);
    }
}