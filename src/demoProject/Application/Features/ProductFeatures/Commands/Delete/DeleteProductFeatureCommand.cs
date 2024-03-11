using Application.Features.ProductFeatures.Constants;
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

namespace Application.Features.ProductFeatures.Commands.Delete;

public class DeleteProductFeatureCommand : IRequest<DeletedProductFeatureResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, ProductFeaturesOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetProductFeatures";

    public class DeleteProductFeatureCommandHandler : IRequestHandler<DeleteProductFeatureCommand, DeletedProductFeatureResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductFeatureRepository _productFeatureRepository;
        private readonly ProductFeatureBusinessRules _productFeatureBusinessRules;

        public DeleteProductFeatureCommandHandler(IMapper mapper, IProductFeatureRepository productFeatureRepository,
                                         ProductFeatureBusinessRules productFeatureBusinessRules)
        {
            _mapper = mapper;
            _productFeatureRepository = productFeatureRepository;
            _productFeatureBusinessRules = productFeatureBusinessRules;
        }

        public async Task<DeletedProductFeatureResponse> Handle(DeleteProductFeatureCommand request, CancellationToken cancellationToken)
        {
            ProductFeature? productFeature = await _productFeatureRepository.GetAsync(predicate: pf => pf.Id == request.Id, cancellationToken: cancellationToken);
            await _productFeatureBusinessRules.ProductFeatureShouldExistWhenSelected(productFeature);

            await _productFeatureRepository.DeleteAsync(productFeature!);

            DeletedProductFeatureResponse response = _mapper.Map<DeletedProductFeatureResponse>(productFeature);
            return response;
        }
    }
}