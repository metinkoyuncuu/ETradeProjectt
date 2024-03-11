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

namespace Application.Features.ProductCategories.Commands.Update;

public class UpdateProductCategoryCommand : IRequest<UpdatedProductCategoryResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int CategoryId { get; set; }

    public string[] Roles => new[] { Admin, Write, ProductCategoriesOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetProductCategories";

    public class UpdateProductCategoryCommandHandler : IRequestHandler<UpdateProductCategoryCommand, UpdatedProductCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly ProductCategoryBusinessRules _productCategoryBusinessRules;

        public UpdateProductCategoryCommandHandler(IMapper mapper, IProductCategoryRepository productCategoryRepository,
                                         ProductCategoryBusinessRules productCategoryBusinessRules)
        {
            _mapper = mapper;
            _productCategoryRepository = productCategoryRepository;
            _productCategoryBusinessRules = productCategoryBusinessRules;
        }

        public async Task<UpdatedProductCategoryResponse> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            ProductCategory? productCategory = await _productCategoryRepository.GetAsync(predicate: pc => pc.Id == request.Id, cancellationToken: cancellationToken);
            await _productCategoryBusinessRules.ProductCategoryShouldExistWhenSelected(productCategory);
            productCategory = _mapper.Map(request, productCategory);

            await _productCategoryRepository.UpdateAsync(productCategory!);

            UpdatedProductCategoryResponse response = _mapper.Map<UpdatedProductCategoryResponse>(productCategory);
            return response;
        }
    }
}