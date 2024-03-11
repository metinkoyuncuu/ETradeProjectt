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

namespace Application.Features.ProductFeatureTables.Commands.Update;

public class UpdateProductFeatureTableCommand : IRequest<UpdatedProductFeatureTableResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string Column { get; set; }
    public string Description { get; set; }
    public int ProductFeatureId { get; set; }

    public string[] Roles => new[] { Admin, Write, ProductFeatureTablesOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetProductFeatureTables";

    public class UpdateProductFeatureTableCommandHandler : IRequestHandler<UpdateProductFeatureTableCommand, UpdatedProductFeatureTableResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductFeatureTableRepository _productFeatureTableRepository;
        private readonly ProductFeatureTableBusinessRules _productFeatureTableBusinessRules;

        public UpdateProductFeatureTableCommandHandler(IMapper mapper, IProductFeatureTableRepository productFeatureTableRepository,
                                         ProductFeatureTableBusinessRules productFeatureTableBusinessRules)
        {
            _mapper = mapper;
            _productFeatureTableRepository = productFeatureTableRepository;
            _productFeatureTableBusinessRules = productFeatureTableBusinessRules;
        }

        public async Task<UpdatedProductFeatureTableResponse> Handle(UpdateProductFeatureTableCommand request, CancellationToken cancellationToken)
        {
            ProductFeatureTable? productFeatureTable = await _productFeatureTableRepository.GetAsync(predicate: pft => pft.Id == request.Id, cancellationToken: cancellationToken);
            await _productFeatureTableBusinessRules.ProductFeatureTableShouldExistWhenSelected(productFeatureTable);
            productFeatureTable = _mapper.Map(request, productFeatureTable);

            await _productFeatureTableRepository.UpdateAsync(productFeatureTable!);

            UpdatedProductFeatureTableResponse response = _mapper.Map<UpdatedProductFeatureTableResponse>(productFeatureTable);
            return response;
        }
    }
}