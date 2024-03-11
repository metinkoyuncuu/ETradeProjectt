using Application.Features.ProductFeatureTables.Constants;
using Application.Features.ProductFeatureTables.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.ProductFeatureTables.Constants.ProductFeatureTablesOperationClaims;

namespace Application.Features.ProductFeatureTables.Commands.Create;

public class CreateProductFeatureTableCommand : IRequest<CreatedProductFeatureTableResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Column { get; set; }
    public string Description { get; set; }
    public int ProductFeatureId { get; set; }

    public string[] Roles => new[] { Admin, Write, ProductFeatureTablesOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetProductFeatureTables";

    public class CreateProductFeatureTableCommandHandler : IRequestHandler<CreateProductFeatureTableCommand, CreatedProductFeatureTableResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductFeatureTableRepository _productFeatureTableRepository;
        private readonly ProductFeatureTableBusinessRules _productFeatureTableBusinessRules;

        public CreateProductFeatureTableCommandHandler(IMapper mapper, IProductFeatureTableRepository productFeatureTableRepository,
                                         ProductFeatureTableBusinessRules productFeatureTableBusinessRules)
        {
            _mapper = mapper;
            _productFeatureTableRepository = productFeatureTableRepository;
            _productFeatureTableBusinessRules = productFeatureTableBusinessRules;
        }

        public async Task<CreatedProductFeatureTableResponse> Handle(CreateProductFeatureTableCommand request, CancellationToken cancellationToken)
        {
            ProductFeatureTable productFeatureTable = _mapper.Map<ProductFeatureTable>(request);

            await _productFeatureTableRepository.AddAsync(productFeatureTable);

            CreatedProductFeatureTableResponse response = _mapper.Map<CreatedProductFeatureTableResponse>(productFeatureTable);
            return response;
        }
    }
}