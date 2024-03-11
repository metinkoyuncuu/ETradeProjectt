using Application.Features.ProductCategories.Constants;
using Application.Features.ProductCategories.Constants;
using Application.Features.ProductCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.ProductCategories.Constants.ProductCategoriesOperationClaims;

namespace Application.Features.ProductCategories.Commands.Delete;

public class DeleteProductCategoryCommand : IRequest<DeletedProductCategoryResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, ProductCategoriesOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetProductCategories";

    public class DeleteProductCategoryCommandHandler : IRequestHandler<DeleteProductCategoryCommand, DeletedProductCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly ProductCategoryBusinessRules _productCategoryBusinessRules;

        public DeleteProductCategoryCommandHandler(IMapper mapper, IProductCategoryRepository productCategoryRepository,
                                         ProductCategoryBusinessRules productCategoryBusinessRules)
        {
            _mapper = mapper;
            _productCategoryRepository = productCategoryRepository;
            _productCategoryBusinessRules = productCategoryBusinessRules;
        }

        public async Task<DeletedProductCategoryResponse> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
        {
            ProductCategory? productCategory = await _productCategoryRepository.GetAsync(predicate: pc => pc.Id == request.Id, cancellationToken: cancellationToken);
            await _productCategoryBusinessRules.ProductCategoryShouldExistWhenSelected(productCategory);

            await _productCategoryRepository.DeleteAsync(productCategory!);

            DeletedProductCategoryResponse response = _mapper.Map<DeletedProductCategoryResponse>(productCategory);
            return response;
        }
    }
}