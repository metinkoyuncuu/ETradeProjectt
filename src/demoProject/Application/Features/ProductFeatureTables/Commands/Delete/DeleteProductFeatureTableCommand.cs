using Application.Features.ProductFeatureTables.Constants;
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

namespace Application.Features.ProductFeatureTables.Commands.Delete;

public class DeleteProductFeatureTableCommand : IRequest<DeletedProductFeatureTableResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, ProductFeatureTablesOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetProductFeatureTables";

    public class DeleteProductFeatureTableCommandHandler : IRequestHandler<DeleteProductFeatureTableCommand, DeletedProductFeatureTableResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductFeatureTableRepository _productFeatureTableRepository;
        private readonly ProductFeatureTableBusinessRules _productFeatureTableBusinessRules;

        public DeleteProductFeatureTableCommandHandler(IMapper mapper, IProductFeatureTableRepository productFeatureTableRepository,
                                         ProductFeatureTableBusinessRules productFeatureTableBusinessRules)
        {
            _mapper = mapper;
            _productFeatureTableRepository = productFeatureTableRepository;
            _productFeatureTableBusinessRules = productFeatureTableBusinessRules;
        }

        public async Task<DeletedProductFeatureTableResponse> Handle(DeleteProductFeatureTableCommand request, CancellationToken cancellationToken)
        {
            ProductFeatureTable? productFeatureTable = await _productFeatureTableRepository.GetAsync(predicate: pft => pft.Id == request.Id, cancellationToken: cancellationToken);
            await _productFeatureTableBusinessRules.ProductFeatureTableShouldExistWhenSelected(productFeatureTable);

            await _productFeatureTableRepository.DeleteAsync(productFeatureTable!);

            DeletedProductFeatureTableResponse response = _mapper.Map<DeletedProductFeatureTableResponse>(productFeatureTable);
            return response;
        }
    }
}