using Application.Features.OrderProducts.Commands.Create;
using Application.Features.OrderProducts.Commands.Delete;
using Application.Features.OrderProducts.Commands.Update;
using Application.Features.OrderProducts.Queries.GetById;
using Application.Features.OrderProducts.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderProductsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateOrderProductCommand createOrderProductCommand)
    {
        CreatedOrderProductResponse response = await Mediator.Send(createOrderProductCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateOrderProductCommand updateOrderProductCommand)
    {
        UpdatedOrderProductResponse response = await Mediator.Send(updateOrderProductCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedOrderProductResponse response = await Mediator.Send(new DeleteOrderProductCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdOrderProductResponse response = await Mediator.Send(new GetByIdOrderProductQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListOrderProductQuery getListOrderProductQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListOrderProductListItemDto> response = await Mediator.Send(getListOrderProductQuery);
        return Ok(response);
    }
}