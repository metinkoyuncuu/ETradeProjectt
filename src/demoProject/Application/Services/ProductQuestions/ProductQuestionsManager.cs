using Application.Features.ProductQuestions.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProductQuestions;

public class ProductQuestionsManager : IProductQuestionsService
{
    private readonly IProductQuestionRepository _productQuestionRepository;
    private readonly ProductQuestionBusinessRules _productQuestionBusinessRules;

    public ProductQuestionsManager(IProductQuestionRepository productQuestionRepository, ProductQuestionBusinessRules productQuestionBusinessRules)
    {
        _productQuestionRepository = productQuestionRepository;
        _productQuestionBusinessRules = productQuestionBusinessRules;
    }

    public async Task<ProductQuestion?> GetAsync(
        Expression<Func<ProductQuestion, bool>> predicate,
        Func<IQueryable<ProductQuestion>, IIncludableQueryable<ProductQuestion, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ProductQuestion? productQuestion = await _productQuestionRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return productQuestion;
    }

    public async Task<IPaginate<ProductQuestion>?> GetListAsync(
        Expression<Func<ProductQuestion, bool>>? predicate = null,
        Func<IQueryable<ProductQuestion>, IOrderedQueryable<ProductQuestion>>? orderBy = null,
        Func<IQueryable<ProductQuestion>, IIncludableQueryable<ProductQuestion, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ProductQuestion> productQuestionList = await _productQuestionRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return productQuestionList;
    }

    public async Task<ProductQuestion> AddAsync(ProductQuestion productQuestion)
    {
        ProductQuestion addedProductQuestion = await _productQuestionRepository.AddAsync(productQuestion);

        return addedProductQuestion;
    }

    public async Task<ProductQuestion> UpdateAsync(ProductQuestion productQuestion)
    {
        ProductQuestion updatedProductQuestion = await _productQuestionRepository.UpdateAsync(productQuestion);

        return updatedProductQuestion;
    }

    public async Task<ProductQuestion> DeleteAsync(ProductQuestion productQuestion, bool permanent = false)
    {
        ProductQuestion deletedProductQuestion = await _productQuestionRepository.DeleteAsync(productQuestion);

        return deletedProductQuestion;
    }
}
