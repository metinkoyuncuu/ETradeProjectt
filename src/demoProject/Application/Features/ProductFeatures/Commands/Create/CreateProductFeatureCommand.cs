using Application.Features.ProductFeatures.Constants;
using Application.Features.ProductFeatures.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.ProductFeatures.Constants.ProductFeaturesOperationClaims;

namespace Application.Features.ProductFeatures.Commands.Create;

public class CreateProductFeatureCommand : IRequest<CreatedProductFeatureResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int ProductId { get; set; }
    public string Header { get; set; }

    public string[] Roles => new[] { Admin, Write, ProductFeaturesOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetProductFeatures";

    public class CreateProductFeatureCommandHandler : IRequestHandler<CreateProductFeatureCommand, CreatedProductFeatureResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductFeatureRepository _productFeatureRepository;
        private readonly ProductFeatureBusinessRules _productFeatureBusinessRules;

        public CreateProductFeatureCommandHandler(IMapper mapper, IProductFeatureRepository productFeatureRepository,
                                         ProductFeatureBusinessRules productFeatureBusinessRules)
        {
            _mapper = mapper;
            _productFeatureRepository = productFeatureRepository;
            _productFeatureBusinessRules = productFeatureBusinessRules;
        }

        public async Task<CreatedProductFeatureResponse> Handle(CreateProductFeatureCommand request, CancellationToken cancellationToken)
        {
            ProductFeature productFeature = _mapper.Map<ProductFeature>(request);

            await _productFeatureRepository.AddAsync(productFeature);

            CreatedProductFeatureResponse response = _mapper.Map<CreatedProductFeatureResponse>(productFeature);
            return response;
        }
    }
}