using Application.Features.ProductColors.Constants;
using Application.Features.ProductColors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.ProductColors.Constants.ProductColorsOperationClaims;

namespace Application.Features.ProductColors.Commands.Create;

public class CreateProductColorCommand : IRequest<CreatedProductColorResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int ProductId { get; set; }
    public int ColorId { get; set; }
    public int QuantityInStock { get; set; }
    public int ImageId { get; set; }

    public string[] Roles => new[] { Admin, Write, ProductColorsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetProductColors";

    public class CreateProductColorCommandHandler : IRequestHandler<CreateProductColorCommand, CreatedProductColorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductColorRepository _productColorRepository;
        private readonly ProductColorBusinessRules _productColorBusinessRules;

        public CreateProductColorCommandHandler(IMapper mapper, IProductColorRepository productColorRepository,
                                         ProductColorBusinessRules productColorBusinessRules)
        {
            _mapper = mapper;
            _productColorRepository = productColorRepository;
            _productColorBusinessRules = productColorBusinessRules;
        }

        public async Task<CreatedProductColorResponse> Handle(CreateProductColorCommand request, CancellationToken cancellationToken)
        {
            ProductColor productColor = _mapper.Map<ProductColor>(request);

            await _productColorRepository.AddAsync(productColor);

            CreatedProductColorResponse response = _mapper.Map<CreatedProductColorResponse>(productColor);
            return response;
        }
    }
}