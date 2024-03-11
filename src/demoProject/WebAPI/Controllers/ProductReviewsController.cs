using Application.Features.ProductReviews.Commands.Create;
using Application.Features.ProductReviews.Commands.Delete;
using Application.Features.ProductReviews.Commands.Update;
using Application.Features.ProductReviews.Queries.GetById;
using Application.Features.ProductReviews.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductReviewsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProductReviewCommand createProductReviewCommand)
    {
        CreatedProductReviewResponse response = await Mediator.Send(createProductReviewCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProductReviewCommand updateProductReviewCommand)
    {
        UpdatedProductReviewResponse response = await Mediator.Send(updateProductReviewCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedProductReviewResponse response = await Mediator.Send(new DeleteProductReviewCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdProductReviewResponse response = await Mediator.Send(new GetByIdProductReviewQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListProductReviewQuery getListProductReviewQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListProductReviewListItemDto> response = await Mediator.Send(getListProductReviewQuery);
        return Ok(response);
    }
}