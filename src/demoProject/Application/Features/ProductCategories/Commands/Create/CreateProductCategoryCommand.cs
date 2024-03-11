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

namespace Application.Features.ProductCategories.Commands.Create;

public class CreateProductCategoryCommand : IRequest<CreatedProductCategoryResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int ProductId { get; set; }
    public int CategoryId { get; set; }

    public string[] Roles => new[] { Admin, Write, ProductCategoriesOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetProductCategories";

    public class CreateProductCategoryCommandHandler : IRequestHandler<CreateProductCategoryCommand, CreatedProductCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly ProductCategoryBusinessRules _productCategoryBusinessRules;

        public CreateProductCategoryCommandHandler(IMapper mapper, IProductCategoryRepository productCategoryRepository,
                                         ProductCategoryBusinessRules productCategoryBusinessRules)
        {
            _mapper = mapper;
            _productCategoryRepository = productCategoryRepository;
            _productCategoryBusinessRules = productCategoryBusinessRules;
        }

        public async Task<CreatedProductCategoryResponse> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            ProductCategory productCategory = _mapper.Map<ProductCategory>(request);

            await _productCategoryRepository.AddAsync(productCategory);

            CreatedProductCategoryResponse response = _mapper.Map<CreatedProductCategoryResponse>(productCategory);
            return response;
        }
    }
}