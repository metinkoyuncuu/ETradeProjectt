using Application.Features.ShopImages.Constants;
using Application.Features.ShopImages.Constants;
using Application.Features.ShopImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.ShopImages.Constants.ShopImagesOperationClaims;

namespace Application.Features.ShopImages.Commands.Delete;

public class DeleteShopImageCommand : IRequest<DeletedShopImageResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, ShopImagesOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetShopImages";

    public class DeleteShopImageCommandHandler : IRequestHandler<DeleteShopImageCommand, DeletedShopImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IShopImageRepository _shopImageRepository;
        private readonly ShopImageBusinessRules _shopImageBusinessRules;

        public DeleteShopImageCommandHandler(IMapper mapper, IShopImageRepository shopImageRepository,
                                         ShopImageBusinessRules shopImageBusinessRules)
        {
            _mapper = mapper;
            _shopImageRepository = shopImageRepository;
            _shopImageBusinessRules = shopImageBusinessRules;
        }

        public async Task<DeletedShopImageResponse> Handle(DeleteShopImageCommand request, CancellationToken cancellationToken)
        {
            ShopImage? shopImage = await _shopImageRepository.GetAsync(predicate: si => si.Id == request.Id, cancellationToken: cancellationToken);
            await _shopImageBusinessRules.ShopImageShouldExistWhenSelected(shopImage);

            await _shopImageRepository.DeleteAsync(shopImage!);

            DeletedShopImageResponse response = _mapper.Map<DeletedShopImageResponse>(shopImage);
            return response;
        }
    }
}