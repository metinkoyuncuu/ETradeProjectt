using Application.Features.ProductFeatures.Constants;
using Application.Features.ProductFeatures.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ProductFeatures.Constants.ProductFeaturesOperationClaims;

namespace Application.Features.ProductFeatures.Queries.GetById;

public class GetByIdProductFeatureQuery : IRequest<GetByIdProductFeatureResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdProductFeatureQueryHandler : IRequestHandler<GetByIdProductFeatureQuery, GetByIdProductFeatureResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductFeatureRepository _productFeatureRepository;
        private readonly ProductFeatureBusinessRules _productFeatureBusinessRules;

        public GetByIdProductFeatureQueryHandler(IMapper mapper, IProductFeatureRepository productFeatureRepository, ProductFeatureBusinessRules productFeatureBusinessRules)
        {
            _mapper = mapper;
            _productFeatureRepository = productFeatureRepository;
            _productFeatureBusinessRules = productFeatureBusinessRules;
        }

        public async Task<GetByIdProductFeatureResponse> Handle(GetByIdProductFeatureQuery request, CancellationToken cancellationToken)
        {
            ProductFeature? productFeature = await _productFeatureRepository.GetAsync(predicate: pf => pf.Id == request.Id, cancellationToken: cancellationToken);
            await _productFeatureBusinessRules.ProductFeatureShouldExistWhenSelected(productFeature);

            GetByIdProductFeatureResponse response = _mapper.Map<GetByIdProductFeatureResponse>(productFeature);
            return response;
        }
    }
}