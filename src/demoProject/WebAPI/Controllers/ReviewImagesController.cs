using Application.Features.ReviewImages.Commands.Create;
using Application.Features.ReviewImages.Commands.Delete;
using Application.Features.ReviewImages.Commands.Update;
using Application.Features.ReviewImages.Queries.GetById;
using Application.Features.ReviewImages.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReviewImagesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateReviewImageCommand createReviewImageCommand)
    {
        CreatedReviewImageResponse response = await Mediator.Send(createReviewImageCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateReviewImageCommand updateReviewImageCommand)
    {
        UpdatedReviewImageResponse response = await Mediator.Send(updateReviewImageCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedReviewImageResponse response = await Mediator.Send(new DeleteReviewImageCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdReviewImageResponse response = await Mediator.Send(new GetByIdReviewImageQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListReviewImageQuery getListReviewImageQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListReviewImageListItemDto> response = await Mediator.Send(getListReviewImageQuery);
        return Ok(response);
    }
}