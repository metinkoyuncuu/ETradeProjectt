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

namespace Application.Features.ShopImages.Commands.Create;

public class CreateShopImageCommand : IRequest<CreatedShopImageResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int ShopId { get; set; }
    public int ImageId { get; set; }
    public string ImageType { get; set; }

    public string[] Roles => new[] { Admin, Write, ShopImagesOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetShopImages";

    public class CreateShopImageCommandHandler : IRequestHandler<CreateShopImageCommand, CreatedShopImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly IShopImageRepository _shopImageRepository;
        private readonly ShopImageBusinessRules _shopImageBusinessRules;

        public CreateShopImageCommandHandler(IMapper mapper, IShopImageRepository shopImageRepository,
                                         ShopImageBusinessRules shopImageBusinessRules)
        {
            _mapper = mapper;
            _shopImageRepository = shopImageRepository;
            _shopImageBusinessRules = shopImageBusinessRules;
        }

        public async Task<CreatedShopImageResponse> Handle(CreateShopImageCommand request, CancellationToken cancellationToken)
        {
            ShopImage shopImage = _mapper.Map<ShopImage>(request);

            await _shopImageRepository.AddAsync(shopImage);

            CreatedShopImageResponse response = _mapper.Map<CreatedShopImageResponse>(shopImage);
            return response;
        }
    }
}