using Application.Features.ProductTags.Constants;
using Application.Features.ProductTags.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.ProductTags.Constants.ProductTagsOperationClaims;

namespace Application.Features.ProductTags.Commands.Create;

public class CreateProductTagCommand : IRequest<CreatedProductTagResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int ProductId { get; set; }
    public int TagId { get; set; }

    public string[] Roles => new[] { Admin, Write, ProductTagsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetProductTags";

    public class CreateProductTagCommandHandler : IRequestHandler<CreateProductTagCommand, CreatedProductTagResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductTagRepository _productTagRepository;
        private readonly ProductTagBusinessRules _productTagBusinessRules;

        public CreateProductTagCommandHandler(IMapper mapper, IProductTagRepository productTagRepository,
                                         ProductTagBusinessRules productTagBusinessRules)
        {
            _mapper = mapper;
            _productTagRepository = productTagRepository;
            _productTagBusinessRules = productTagBusinessRules;
        }

        public async Task<CreatedProductTagResponse> Handle(CreateProductTagCommand request, CancellationToken cancellationToken)
        {
            ProductTag productTag = _mapper.Map<ProductTag>(request);

            await _productTagRepository.AddAsync(productTag);

            CreatedProductTagResponse response = _mapper.Map<CreatedProductTagResponse>(productTag);
            return response;
        }
    }
}