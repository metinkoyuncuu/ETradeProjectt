using Application.Features.ShopImages.Commands.Create;
using Application.Features.ShopImages.Commands.Delete;
using Application.Features.ShopImages.Commands.Update;
using Application.Features.ShopImages.Queries.GetById;
using Application.Features.ShopImages.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShopImagesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateShopImageCommand createShopImageCommand)
    {
        CreatedShopImageResponse response = await Mediator.Send(createShopImageCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateShopImageCommand updateShopImageCommand)
    {
        UpdatedShopImageResponse response = await Mediator.Send(updateShopImageCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedShopImageResponse response = await Mediator.Send(new DeleteShopImageCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdShopImageResponse response = await Mediator.Send(new GetByIdShopImageQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListShopImageQuery getListShopImageQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListShopImageListItemDto> response = await Mediator.Send(getListShopImageQuery);
        return Ok(response);
    }
}