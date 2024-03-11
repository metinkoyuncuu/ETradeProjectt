using Application.Features.ProductTags.Constants;
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

namespace Application.Features.ProductTags.Commands.Delete;

public class DeleteProductTagCommand : IRequest<DeletedProductTagResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, ProductTagsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetProductTags";

    public class DeleteProductTagCommandHandler : IRequestHandler<DeleteProductTagCommand, DeletedProductTagResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductTagRepository _productTagRepository;
        private readonly ProductTagBusinessRules _productTagBusinessRules;

        public DeleteProductTagCommandHandler(IMapper mapper, IProductTagRepository productTagRepository,
                                         ProductTagBusinessRules productTagBusinessRules)
        {
            _mapper = mapper;
            _productTagRepository = productTagRepository;
            _productTagBusinessRules = productTagBusinessRules;
        }

        public async Task<DeletedProductTagResponse> Handle(DeleteProductTagCommand request, CancellationToken cancellationToken)
        {
            ProductTag? productTag = await _productTagRepository.GetAsync(predicate: pt => pt.Id == request.Id, cancellationToken: cancellationToken);
            await _productTagBusinessRules.ProductTagShouldExistWhenSelected(productTag);

            await _productTagRepository.DeleteAsync(productTag!);

            DeletedProductTagResponse response = _mapper.Map<DeletedProductTagResponse>(productTag);
            return response;
        }
    }
}