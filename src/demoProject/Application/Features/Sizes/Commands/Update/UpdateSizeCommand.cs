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

namespace Application.Features.Sizes.Commands.Update;

public class UpdateSizeCommand : IRequest<UpdatedSizeResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsVerified { get; set; }

    public string[] Roles => new[] { Admin, Write, SizesOperationClaims.Update };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetSizes";

    public class UpdateSizeCommandHandler : IRequestHandler<UpdateSizeCommand, UpdatedSizeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISizeRepository _sizeRepository;
        private readonly SizeBusinessRules _sizeBusinessRules;

        public UpdateSizeCommandHandler(IMapper mapper, ISizeRepository sizeRepository,
                                         SizeBusinessRules sizeBusinessRules)
        {
            _mapper = mapper;
            _sizeRepository = sizeRepository;
            _sizeBusinessRules = sizeBusinessRules;
        }

        public async Task<UpdatedSizeResponse> Handle(UpdateSizeCommand request, CancellationToken cancellationToken)
        {
            Size? size = await _sizeRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _sizeBusinessRules.SizeShouldExistWhenSelected(size);
            size = _mapper.Map(request, size);

            await _sizeRepository.UpdateAsync(size!);

            UpdatedSizeResponse response = _mapper.Map<UpdatedSizeResponse>(size);
            return response;
        }
    }
}