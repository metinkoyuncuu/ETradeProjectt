using Application.Features.CustomerCreditCards.Commands.Create;
using Application.Features.CustomerCreditCards.Commands.Delete;
using Application.Features.CustomerCreditCards.Commands.Update;
using Application.Features.CustomerCreditCards.Queries.GetById;
using Application.Features.CustomerCreditCards.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerCreditCardsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCustomerCreditCardCommand createCustomerCreditCardCommand)
    {
        CreatedCustomerCreditCardResponse response = await Mediator.Send(createCustomerCreditCardCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCustomerCreditCardCommand updateCustomerCreditCardCommand)
    {
        UpdatedCustomerCreditCardResponse response = await Mediator.Send(updateCustomerCreditCardCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedCustomerCreditCardResponse response = await Mediator.Send(new DeleteCustomerCreditCardCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdCustomerCreditCardResponse response = await Mediator.Send(new GetByIdCustomerCreditCardQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCustomerCreditCardQuery getListCustomerCreditCardQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCustomerCreditCardListItemDto> response = await Mediator.Send(getListCustomerCreditCardQuery);
        return Ok(response);
    }
}