using Application.Features.ProductQuestions.Commands.Create;
using Application.Features.ProductQuestions.Commands.Delete;
using Application.Features.ProductQuestions.Commands.Update;
using Application.Features.ProductQuestions.Queries.GetById;
using Application.Features.ProductQuestions.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductQuestionsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateProductQuestionCommand createProductQuestionCommand)
    {
        CreatedProductQuestionResponse response = await Mediator.Send(createProductQuestionCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProductQuestionCommand updateProductQuestionCommand)
    {
        UpdatedProductQuestionResponse response = await Mediator.Send(updateProductQuestionCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedProductQuestionResponse response = await Mediator.Send(new DeleteProductQuestionCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdProductQuestionResponse response = await Mediator.Send(new GetByIdProductQuestionQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListProductQuestionQuery getListProductQuestionQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListProductQuestionListItemDto> response = await Mediator.Send(getListProductQuestionQuery);
        return Ok(response);
    }
}