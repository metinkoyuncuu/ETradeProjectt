using Application.Features.ProductCategories.Constants;
using Application.Features.ProductCategories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ProductCategories.Constants.ProductCategoriesOperationClaims;

namespace Application.Features.ProductCategories.Queries.GetById;

public class GetByIdProductCategoryQuery : IRequest<GetByIdProductCategoryResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdProductCategoryQueryHandler : IRequestHandler<GetByIdProductCategoryQuery, GetByIdProductCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly ProductCategoryBusinessRules _productCategoryBusinessRules;

        public GetByIdProductCategoryQueryHandler(IMapper mapper, IProductCategoryRepository productCategoryRepository, ProductCategoryBusinessRules productCategoryBusinessRules)
        {
            _mapper = mapper;
            _productCategoryRepository = productCategoryRepository;
            _productCategoryBusinessRules = productCategoryBusinessRules;
        }

        public async Task<GetByIdProductCategoryResponse> Handle(GetByIdProductCategoryQuery request, CancellationToken cancellationToken)
        {
            ProductCategory? productCategory = await _productCategoryRepository.GetAsync(predicate: pc => pc.Id == request.Id, cancellationToken: cancellationToken);
            await _productCategoryBusinessRules.ProductCategoryShouldExistWhenSelected(productCategory);

            GetByIdProductCategoryResponse response = _mapper.Map<GetByIdProductCategoryResponse>(productCategory);
            return response;
        }
    }
}