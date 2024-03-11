using Application.Features.ProductQuestions.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ProductQuestions.Rules;

public class ProductQuestionBusinessRules : BaseBusinessRules
{
    private readonly IProductQuestionRepository _productQuestionRepository;

    public ProductQuestionBusinessRules(IProductQuestionRepository productQuestionRepository)
    {
        _productQuestionRepository = productQuestionRepository;
    }

    public Task ProductQuestionShouldExistWhenSelected(ProductQuestion? productQuestion)
    {
        if (productQuestion == null)
            throw new BusinessException(ProductQuestionsBusinessMessages.ProductQuestionNotExists);
        return Task.CompletedTask;
    }

    public async Task ProductQuestionIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ProductQuestion? productQuestion = await _productQuestionRepository.GetAsync(
            predicate: pq => pq.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ProductQuestionShouldExistWhenSelected(productQuestion);
    }
}