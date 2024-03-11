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

namespace Application.Features.ShopImages.Commands.Update;

public class UpdateShopImageCommand : IRequest<UpdatedShopImageResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int ShopId { get; set; }
    public int ImageId { get; set; }
    public string ImageType { get; set; }

    public string[] Roles => new[] { Admin, Write, ShopImagesOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetShopImages";

    public class UpdateShopImageCommandHandler : IRequestHandler<UpdateShopImageCommand, UpdatedShopImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IShopImageRepository _shopImageRepository;
        private readonly ShopImageBusinessRules _shopImageBusinessRules;

        public UpdateShopImageCommandHandler(IMapper mapper, IShopImageRepository shopImageRepository,
                                         ShopImageBusinessRules shopImageBusinessRules)
        {
            _mapper = mapper;
            _shopImageRepository = shopImageRepository;
            _shopImageBusinessRules = shopImageBusinessRules;
        }

        public async Task<UpdatedShopImageResponse> Handle(UpdateShopImageCommand request, CancellationToken cancellationToken)
        {
            ShopImage? shopImage = await _shopImageRepository.GetAsync(predicate: si => si.Id == request.Id, cancellationToken: cancellationToken);
            await _shopImageBusinessRules.ShopImageShouldExistWhenSelected(shopImage);
            shopImage = _mapper.Map(request, shopImage);

            await _shopImageRepository.UpdateAsync(shopImage!);

            UpdatedShopImageResponse response = _mapper.Map<UpdatedShopImageResponse>(shopImage);
            return response;
        }
    }
}