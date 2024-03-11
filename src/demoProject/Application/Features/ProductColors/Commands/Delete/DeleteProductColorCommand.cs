using Application.Features.ProductColors.Constants;
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

namespace Application.Features.ProductColors.Commands.Delete;

public class DeleteProductColorCommand : IRequest<DeletedProductColorResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, ProductColorsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetProductColors";

    public class DeleteProductColorCommandHandler : IRequestHandler<DeleteProductColorCommand, DeletedProductColorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductColorRepository _productColorRepository;
        private readonly ProductColorBusinessRules _productColorBusinessRules;

        public DeleteProductColorCommandHandler(IMapper mapper, IProductColorRepository productColorRepository,
                                         ProductColorBusinessRules productColorBusinessRules)
        {
            _mapper = mapper;
            _productColorRepository = productColorRepository;
            _productColorBusinessRules = productColorBusinessRules;
        }

        public async Task<DeletedProductColorResponse> Handle(DeleteProductColorCommand request, CancellationToken cancellationToken)
        {
            ProductColor? productColor = await _productColorRepository.GetAsync(predicate: pc => pc.Id == request.Id, cancellationToken: cancellationToken);
            await _productColorBusinessRules.ProductColorShouldExistWhenSelected(productColor);

            await _productColorRepository.DeleteAsync(productColor!);

            DeletedProductColorResponse response = _mapper.Map<DeletedProductColorResponse>(productColor);
            return response;
        }
    }
}