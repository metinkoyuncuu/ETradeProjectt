using Application.Features.ReviewFeedbacks.Commands.Create;
using Application.Features.ReviewFeedbacks.Commands.Delete;
using Application.Features.ReviewFeedbacks.Commands.Update;
using Application.Features.ReviewFeedbacks.Queries.GetById;
using Application.Features.ReviewFeedbacks.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReviewFeedbacksController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateReviewFeedbackCommand createReviewFeedbackCommand)
    {
        CreatedReviewFeedbackResponse response = await Mediator.Send(createReviewFeedbackCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateReviewFeedbackCommand updateReviewFeedbackCommand)
    {
        UpdatedReviewFeedbackResponse response = await Mediator.Send(updateReviewFeedbackCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedReviewFeedbackResponse response = await Mediator.Send(new DeleteReviewFeedbackCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdReviewFeedbackResponse response = await Mediator.Send(new GetByIdReviewFeedbackQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListReviewFeedbackQuery getListReviewFeedbackQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListReviewFeedbackListItemDto> response = await Mediator.Send(getListReviewFeedbackQuery);
        return Ok(response);
    }
}