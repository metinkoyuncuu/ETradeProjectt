using Application.Features.Sizes.Constants;
using Application.Features.Sizes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Sizes.Constants.SizesOperationClaims;

namespace Application.Features.Sizes.Commands.Create;

public class CreateSizeCommand : IRequest<CreatedSizeResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string Name { get; set; }
    public bool IsVerified { get; set; }

    public string[] Roles => new[] { Admin, Write, SizesOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetSizes";

    public class CreateSizeCommandHandler : IRequestHandler<CreateSizeCommand, CreatedSizeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISizeRepository _sizeRepository;
        private readonly SizeBusinessRules _sizeBusinessRules;

        public CreateSizeCommandHandler(IMapper mapper, ISizeRepository sizeRepository,
                                         SizeBusinessRules sizeBusinessRules)
        {
            _mapper = mapper;
            _sizeRepository = sizeRepository;
            _sizeBusinessRules = sizeBusinessRules;
        }

        public async Task<CreatedSizeResponse> Handle(CreateSizeCommand request, CancellationToken cancellationToken)
        {
            Size size = _mapper.Map<Size>(request);

            await _sizeRepository.AddAsync(size);

            CreatedSizeResponse response = _mapper.Map<CreatedSizeResponse>(size);
            return response;
        }
    }
}