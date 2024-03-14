using Application.Features.Brands.Constants;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Brands.Constants.BrandsOperationClaims;
using Application.Features.OperationClaims.Constants;
using Application.Services.ContextOperations;

namespace Application.Features.Brands.Commands.Create;

public class CreateBrandCommand : IRequest<CreatedBrandResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public CreateBrandCommand(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
    public bool? IsVerified { get; set; }

    public string[] Roles => new[] { GeneralOperationClaims.Seller };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetBrands";

    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBrandRepository _brandRepository;
        private readonly BrandBusinessRules _brandBusinessRules;
        private readonly IContextOperationsService _contextOperationsService;

        public CreateBrandCommandHandler(IMapper mapper, IBrandRepository brandRepository,
                                         BrandBusinessRules brandBusinessRules, IContextOperationsService contextOperationsService)
        {
            _mapper = mapper;
            _brandRepository = brandRepository;
            _brandBusinessRules = brandBusinessRules;
            _contextOperationsService = contextOperationsService;
        }

        public async Task<CreatedBrandResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            List<string>? getClaims=_contextOperationsService.GetOperationClaims();
            Brand brand = _mapper.Map<Brand>(request);
            brand.IsVerified=getClaims.Contains(GeneralOperationClaims.Admin)?true:false;
            await _brandRepository.AddAsync(brand);

            CreatedBrandResponse response = _mapper.Map<CreatedBrandResponse>(brand);
            return response;
        }
    }
}