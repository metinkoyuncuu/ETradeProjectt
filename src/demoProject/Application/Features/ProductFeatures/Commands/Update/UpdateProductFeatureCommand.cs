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

namespace Application.Features.ProductFeatures.Commands.Update;

public class UpdateProductFeatureCommand : IRequest<UpdatedProductFeatureResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string Header { get; set; }

    public string[] Roles => new[] { Admin, Write, ProductFeaturesOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetProductFeatures";

    public class UpdateProductFeatureCommandHandler : IRequestHandler<UpdateProductFeatureCommand, UpdatedProductFeatureResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductFeatureRepository _productFeatureRepository;
        private readonly ProductFeatureBusinessRules _productFeatureBusinessRules;

        public UpdateProductFeatureCommandHandler(IMapper mapper, IProductFeatureRepository productFeatureRepository,
                                         ProductFeatureBusinessRules productFeatureBusinessRules)
        {
            _mapper = mapper;
            _productFeatureRepository = productFeatureRepository;
            _productFeatureBusinessRules = productFeatureBusinessRules;
        }

        public async Task<UpdatedProductFeatureResponse> Handle(UpdateProductFeatureCommand request, CancellationToken cancellationToken)
        {
            ProductFeature? productFeature = await _productFeatureRepository.GetAsync(predicate: pf => pf.Id == request.Id, cancellationToken: cancellationToken);
            await _productFeatureBusinessRules.ProductFeatureShouldExistWhenSelected(productFeature);
            productFeature = _mapper.Map(request, productFeature);

            await _productFeatureRepository.UpdateAsync(productFeature!);

            UpdatedProductFeatureResponse response = _mapper.Map<UpdatedProductFeatureResponse>(productFeature);
            return response;
        }
    }
}