using Application.Features.CustomerAddresses.Commands.Create;
using Application.Features.CustomerAddresses.Commands.Delete;
using Application.Features.CustomerAddresses.Commands.Update;
using Application.Features.CustomerAddresses.Queries.GetById;
using Application.Features.CustomerAddresses.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerAddressesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCustomerAddressCommand createCustomerAddressCommand)
    {
        CreatedCustomerAddressResponse response = await Mediator.Send(createCustomerAddressCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCustomerAddressCommand updateCustomerAddressCommand)
    {
        UpdatedCustomerAddressResponse response = await Mediator.Send(updateCustomerAddressCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedCustomerAddressResponse response = await Mediator.Send(new DeleteCustomerAddressCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdCustomerAddressResponse response = await Mediator.Send(new GetByIdCustomerAddressQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCustomerAddressQuery getListCustomerAddressQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCustomerAddressListItemDto> response = await Mediator.Send(getListCustomerAddressQuery);
        return Ok(response);
    }
}