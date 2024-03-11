using Application.Features.ProductImages.Constants;
using Application.Features.ProductImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.ProductImages.Constants.ProductImagesOperationClaims;

namespace Application.Features.ProductImages.Commands.Create;

public class CreateProductImageCommand : IRequest<CreatedProductImageResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int ProductId { get; set; }
    public int ImageId { get; set; }

    public string[] Roles => new[] { Admin, Write, ProductImagesOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetProductImages";

    public class CreateProductImageCommandHandler : IRequestHandler<CreateProductImageCommand, CreatedProductImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductImageRepository _productImageRepository;
        private readonly ProductImageBusinessRules _productImageBusinessRules;

        public CreateProductImageCommandHandler(IMapper mapper, IProductImageRepository productImageRepository,
                                         ProductImageBusinessRules productImageBusinessRules)
        {
            _mapper = mapper;
            _productImageRepository = productImageRepository;
            _productImageBusinessRules = productImageBusinessRules;
        }

        public async Task<CreatedProductImageResponse> Handle(CreateProductImageCommand request, CancellationToken cancellationToken)
        {
            ProductImage productImage = _mapper.Map<ProductImage>(request);

            await _productImageRepository.AddAsync(productImage);

            CreatedProductImageResponse response = _mapper.Map<CreatedProductImageResponse>(productImage);
            return response;
        }
    }
}