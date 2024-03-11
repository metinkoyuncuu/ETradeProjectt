using Application.Features.ProductVariants.Constants;
using Application.Features.ProductVariants.Constants;
using Application.Features.ProductVariants.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.ProductVariants.Constants.ProductVariantsOperationClaims;

namespace Application.Features.ProductVariants.Commands.Delete;

public class DeleteProductVariantCommand : IRequest<DeletedProductVariantResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, ProductVariantsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetProductVariants";

    public class DeleteProductVariantCommandHandler : IRequestHandler<DeleteProductVariantCommand, DeletedProductVariantResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductVariantRepository _productVariantRepository;
        private readonly ProductVariantBusinessRules _productVariantBusinessRules;

        public DeleteProductVariantCommandHandler(IMapper mapper, IProductVariantRepository productVariantRepository,
                                         ProductVariantBusinessRules productVariantBusinessRules)
        {
            _mapper = mapper;
            _productVariantRepository = productVariantRepository;
            _productVariantBusinessRules = productVariantBusinessRules;
        }

        public async Task<DeletedProductVariantResponse> Handle(DeleteProductVariantCommand request, CancellationToken cancellationToken)
        {
            ProductVariant? productVariant = await _productVariantRepository.GetAsync(predicate: pv => pv.Id == request.Id, cancellationToken: cancellationToken);
            await _productVariantBusinessRules.ProductVariantShouldExistWhenSelected(productVariant);

            await _productVariantRepository.DeleteAsync(productVariant!);

            DeletedProductVariantResponse response = _mapper.Map<DeletedProductVariantResponse>(productVariant);
            return response;
        }
    }
}