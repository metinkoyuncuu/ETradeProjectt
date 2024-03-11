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

namespace Application.Features.ProductVariants.Commands.Create;

public class CreateProductVariantCommand : IRequest<CreatedProductVariantResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int ProductId { get; set; }
    public int ColorId { get; set; }
    public int QuantityInStock { get; set; }
    public int SizeId { get; set; }

    public string[] Roles => new[] { Admin, Write, ProductVariantsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetProductVariants";

    public class CreateProductVariantCommandHandler : IRequestHandler<CreateProductVariantCommand, CreatedProductVariantResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductVariantRepository _productVariantRepository;
        private readonly ProductVariantBusinessRules _productVariantBusinessRules;

        public CreateProductVariantCommandHandler(IMapper mapper, IProductVariantRepository productVariantRepository,
                                         ProductVariantBusinessRules productVariantBusinessRules)
        {
            _mapper = mapper;
            _productVariantRepository = productVariantRepository;
            _productVariantBusinessRules = productVariantBusinessRules;
        }

        public async Task<CreatedProductVariantResponse> Handle(CreateProductVariantCommand request, CancellationToken cancellationToken)
        {
            ProductVariant productVariant = _mapper.Map<ProductVariant>(request);

            await _productVariantRepository.AddAsync(productVariant);

            CreatedProductVariantResponse response = _mapper.Map<CreatedProductVariantResponse>(productVariant);
            return response;
        }
    }
}