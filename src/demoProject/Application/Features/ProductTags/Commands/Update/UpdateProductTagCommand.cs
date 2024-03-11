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

namespace Application.Features.ProductTags.Commands.Update;

public class UpdateProductTagCommand : IRequest<UpdatedProductTagResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int TagId { get; set; }

    public string[] Roles => new[] { Admin, Write, ProductTagsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetProductTags";

    public class UpdateProductTagCommandHandler : IRequestHandler<UpdateProductTagCommand, UpdatedProductTagResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductTagRepository _productTagRepository;
        private readonly ProductTagBusinessRules _productTagBusinessRules;

        public UpdateProductTagCommandHandler(IMapper mapper, IProductTagRepository productTagRepository,
                                         ProductTagBusinessRules productTagBusinessRules)
        {
            _mapper = mapper;
            _productTagRepository = productTagRepository;
            _productTagBusinessRules = productTagBusinessRules;
        }

        public async Task<UpdatedProductTagResponse> Handle(UpdateProductTagCommand request, CancellationToken cancellationToken)
        {
            ProductTag? productTag = await _productTagRepository.GetAsync(predicate: pt => pt.Id == request.Id, cancellationToken: cancellationToken);
            await _productTagBusinessRules.ProductTagShouldExistWhenSelected(productTag);
            productTag = _mapper.Map(request, productTag);

            await _productTagRepository.UpdateAsync(productTag!);

            UpdatedProductTagResponse response = _mapper.Map<UpdatedProductTagResponse>(productTag);
            return response;
        }
    }
}