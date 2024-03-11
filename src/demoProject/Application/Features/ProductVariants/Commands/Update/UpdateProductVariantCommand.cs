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

namespace Application.Features.ProductVariants.Commands.Update;

public class UpdateProductVariantCommand : IRequest<UpdatedProductVariantResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int ColorId { get; set; }
    public int QuantityInStock { get; set; }
    public int SizeId { get; set; }

    public string[] Roles => new[] { Admin, Write, ProductVariantsOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetProductVariants";

    public class UpdateProductVariantCommandHandler : IRequestHandler<UpdateProductVariantCommand, UpdatedProductVariantResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductVariantRepository _productVariantRepository;
        private readonly ProductVariantBusinessRules _productVariantBusinessRules;

        public UpdateProductVariantCommandHandler(IMapper mapper, IProductVariantRepository productVariantRepository,
                                         ProductVariantBusinessRules productVariantBusinessRules)
        {
            _mapper = mapper;
            _productVariantRepository = productVariantRepository;
            _productVariantBusinessRules = productVariantBusinessRules;
        }

        public async Task<UpdatedProductVariantResponse> Handle(UpdateProductVariantCommand request, CancellationToken cancellationToken)
        {
            ProductVariant? productVariant = await _productVariantRepository.GetAsync(predicate: pv => pv.Id == request.Id, cancellationToken: cancellationToken);
            await _productVariantBusinessRules.ProductVariantShouldExistWhenSelected(productVariant);
            productVariant = _mapper.Map(request, productVariant);

            await _productVariantRepository.UpdateAsync(productVariant!);

            UpdatedProductVariantResponse response = _mapper.Map<UpdatedProductVariantResponse>(productVariant);
            return response;
        }
    }
}