using Application.Features.ProductFeatureTables.Constants;
using Application.Features.ProductFeatureTables.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ProductFeatureTables.Constants.ProductFeatureTablesOperationClaims;

namespace Application.Features.ProductFeatureTables.Queries.GetById;

public class GetByIdProductFeatureTableQuery : IRequest<GetByIdProductFeatureTableResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdProductFeatureTableQueryHandler : IRequestHandler<GetByIdProductFeatureTableQuery, GetByIdProductFeatureTableResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductFeatureTableRepository _productFeatureTableRepository;
        private readonly ProductFeatureTableBusinessRules _productFeatureTableBusinessRules;

        public GetByIdProductFeatureTableQueryHandler(IMapper mapper, IProductFeatureTableRepository productFeatureTableRepository, ProductFeatureTableBusinessRules productFeatureTableBusinessRules)
        {
            _mapper = mapper;
            _productFeatureTableRepository = productFeatureTableRepository;
            _productFeatureTableBusinessRules = productFeatureTableBusinessRules;
        }

        public async Task<GetByIdProductFeatureTableResponse> Handle(GetByIdProductFeatureTableQuery request, CancellationToken cancellationToken)
        {
            ProductFeatureTable? productFeatureTable = await _productFeatureTableRepository.GetAsync(predicate: pft => pft.Id == request.Id, cancellationToken: cancellationToken);
            await _productFeatureTableBusinessRules.ProductFeatureTableShouldExistWhenSelected(productFeatureTable);

            GetByIdProductFeatureTableResponse response = _mapper.Map<GetByIdProductFeatureTableResponse>(productFeatureTable);
            return response;
        }
    }
}